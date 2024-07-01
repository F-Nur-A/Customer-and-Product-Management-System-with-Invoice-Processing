
using System.Data;// its required for ADO 
using System.Data.SqlClient;
using System;

class Product_category_DAL
{
    SqlConnection cn;
    SqlCommand cm;
    SqlDataAdapter da;
    DataTable dt;

    public Product_category_DAL()
    {
        cn = connection.cn;
    }

    public DataTable search_by_pc_id(int pc_id)
    {
        cm = new SqlCommand("SELECT * FROM product_category WHERE pc_id = @pc_id", cn);
        cm.Parameters.AddWithValue("@pc_id", pc_id);
        connection.set_connection();
        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
