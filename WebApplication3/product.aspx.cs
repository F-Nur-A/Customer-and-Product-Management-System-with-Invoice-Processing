using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;

namespace WebApplication3
{
    public partial class product : System.Web.UI.Page
    {
        product_DAL productDAL = new product_DAL();
        factor_DAL factorDAL = new factor_DAL();
        Product_category_DAL categoryDAL = new Product_category_DAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            Product_info productInfo = new Product_info();
            productInfo.pr_id = int.Parse(txtPrId.Text);
            productInfo.name = txtName.Text;
            productInfo.date1 = DateTime.Parse(txtDate1.Text);
            productInfo.price = decimal.Parse(txtPrice.Text);
            productInfo.stock = int.Parse(txtStock.Text);
            productInfo.comment = txtComment.Text;
            productInfo.pc_id = int.Parse(ddlPcId.SelectedValue);

            productDAL.insert(productInfo);
        }

        protected void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            factor_info factorInfo = new factor_info();
            factorInfo.fact_id = int.Parse(txtFactId.Text);
            factorInfo.cust_id = int.Parse(txtCustId.Text);
            factorInfo.fdate = DateTime.Parse(txtFdate.Text);
            factorInfo.amount = int.Parse(txtAmount.Text);
            factorInfo.f_type = txtFType.Text;
            factorInfo.pr_id = int.Parse(txtProductId.Text);

            factorDAL.insert_new_invoice(factorInfo);

        }


        protected void btnShowCategory_Click(object sender, EventArgs e)
        {
            int pc_id = Convert.ToInt32(txtPcId.Text);

            DataTable dtCategory = categoryDAL.search_by_pc_id(pc_id);

            if (dtCategory.Rows.Count > 0)
            {
                DataRow row = dtCategory.Rows[0];
                string categoryInfo = $"pc_id: {row["pc_id"]}\n" +
                                      $"tip: {row["tip"]}\n" +
                                      $"delivery_du: {row["delivery_du"]}\n" +
                                      $"guarantee: {row["guarantee"]}";

                txtCategoryInfo.Text = categoryInfo;
            }
            else
            {
                txtCategoryInfo.Text = "No records found.";
            }
        }
    }
}
