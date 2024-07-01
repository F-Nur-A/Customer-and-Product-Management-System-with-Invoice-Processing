using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class login : System.Web.UI.Page
    {
        Customer_DAL customerDAL = new Customer_DAL(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomersGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int cu_id = int.Parse(txtId.Text);
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string iban = txtIBAN.Text;

            
            customer_info newCustomer = new customer_info()
            {
                cu_id = cu_id,
                name = name,
                family = surname,
                tell = phoneNumber,
                iban = iban
            };
            customerDAL.insert(newCustomer);
            BindCustomersGrid();
        }

        protected void btnInsertJson_Click(object sender, EventArgs e)
        {
            // Veritabanındaki müşteri bilgilerini JSON formatına çevir ve txtJsonResult alanına yaz
            txtJsonResult.Text = GetCustomerDataAsJson();
        }

        private string GetCustomerDataAsJson()
        {
            // Customer_DAL sınıfındaki disp metodu kullanarak müşteri listesini al
            DataTable dtCustomers = customerDAL.disp();
            string jsonText = JsonConvert.SerializeObject(dtCustomers, Formatting.Indented);

            return jsonText;
        }

        protected void btnShowInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcı tarafından girilen cust_id değerini al
                int cust_id;
                if (!int.TryParse(txtCustIdForInvoice.Text, out cust_id))
                {
                    // Geçersiz giriş durumunda kullanıcıya uyarı ver
                    Response.Write("Geçersiz müşteri ID girişi.");
                    return;
                }

                factor_DAL factorDAL = new factor_DAL();
                DataTable dtInvoices = factorDAL.search_by_cust_id(cust_id);
                gridInvoices.DataSource = dtInvoices;
                gridInvoices.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Hata: " + ex.Message);
            }
        }


        protected void btnSearchByName_Click(object sender, EventArgs e)
        {
            // İsimle arama işlemini gerçekleştir
            string name = txtSearchName.Text;
            DataTable dtSearchResults = customerDAL.search_by_name(name);

            gridCustomers.DataSource = dtSearchResults;
            gridCustomers.DataBind();
        }

        protected void btnSearchById_Click(object sender, EventArgs e)
        {
            // id ile arama işlemini gerçekleştir
            int cu_id = int.Parse(txtSearchId.Text);
            DataTable dtSearchResults = customerDAL.search_by_id(cu_id);

            gridCustomers.DataSource = dtSearchResults;
            gridCustomers.DataBind();
        }

        protected void btnSearchByFamily_Click(object sender, EventArgs e)
        {
            // soyad ile arama işlemini gerçekleştir
            string family = txtSearchFamily.Text;
            DataTable dtSearchResults = customerDAL.search_by_familly(family);

            gridCustomers.DataSource = dtSearchResults;
            gridCustomers.DataBind();
        }

        protected void btnSearchByIban_Click(object sender, EventArgs e)
        {
            // iban ile arama işlemini gerçekleştir
            string iban = txtSearchIban.Text;
            DataTable dtSearchResults = customerDAL.search_by_iban(iban);

            gridCustomers.DataSource = dtSearchResults;
            gridCustomers.DataBind();
        }

        protected void btnSearchByTell_Click(object sender, EventArgs e)
        {
            // telefon numarası ile arama işlemini gerçekleştir
            string tell = txtSearchTell.Text;
            DataTable dtSearchResults = customerDAL.search_by_tell(tell);

            gridCustomers.DataSource = dtSearchResults;
            gridCustomers.DataBind();
        }
        protected void gridCustomers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Seçilen satırın düzenleme moduna geçmesi için GridView olayı
            gridCustomers.EditIndex = e.NewEditIndex;

            // Yeniden bağlantıları yükle ve GridView'i güncelle
            BindCustomersGrid();
        }
        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        private void BindCustomersGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM customer";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    gridCustomers.DataSource = null;
                    gridCustomers.DataBind();

                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        gridCustomers.DataSource = dt;
                        gridCustomers.DataBind();
                    }
                    connection.Close();
                }
            }
        }

        protected void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int cu_id = int.Parse(txtDeleteCustomerId.Text);
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM customer WHERE cu_id = @cu_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cu_id", cu_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            BindCustomersGrid();
        }
    }
}

