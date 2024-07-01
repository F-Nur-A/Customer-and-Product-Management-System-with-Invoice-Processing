using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



public class factor_DAL
{
    SqlConnection cn;
    SqlCommand cm;
    SqlDataAdapter da;
    DataTable dt;

    public factor_DAL()
    {
        cn = connection.cn;
    }

    public void insert_new_invoice(factor_info factInfo)
    {
        cm = new SqlCommand("INSERT INTO factor (fact_id, cust_id, fdate, amount, f_type, pr_id) VALUES (@fact_id, @cust_id, @fdate, @amount, @f_type, @pr_id)", cn);
        cm.Parameters.AddWithValue("@fact_id", factInfo.fact_id);
        cm.Parameters.AddWithValue("@cust_id", factInfo.cust_id);
        cm.Parameters.AddWithValue("@fdate", factInfo.fdate);
        cm.Parameters.AddWithValue("@amount", factInfo.amount);
        cm.Parameters.AddWithValue("@f_type", factInfo.f_type);
        cm.Parameters.AddWithValue("@pr_id", factInfo.pr_id);
        connection.set_connection();
        cm.ExecuteNonQuery();
    }
    public DataTable search_by_cust_id(int cust_id)
    {
        cm = new SqlCommand("SELECT fact_id, cust_id, fdate, amount, f_type, pr_id FROM factor WHERE cust_id = @cust_id", cn);
        cm.Parameters.AddWithValue("@cust_id", cust_id);
        connection.set_connection();
        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}

