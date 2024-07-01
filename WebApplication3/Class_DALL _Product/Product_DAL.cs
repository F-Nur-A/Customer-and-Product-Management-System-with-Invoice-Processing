
using System.Data;// its required for ADO 
using System.Data.SqlClient;
using System;

class product_DAL
{
    SqlConnection cn;
    SqlCommand cm;
    SqlDataAdapter da;
    DataTable dt;

    public product_DAL()
    {
        cn = connection.cn;
    }

    // Inserting the product info
    public void insert(Product_info prd_info) 
    {
        cm = new SqlCommand("insert into product (pr_id, name, date1, price, stock, comment, pc_id) values (@pr_id, @name, @date1, @price, @stock, @comment, @pc_id)", cn);
        cm.Parameters.AddWithValue("@pr_id", prd_info.pr_id);
        cm.Parameters.AddWithValue("@name", prd_info.name);
        cm.Parameters.AddWithValue("@date1", prd_info.date1);
        cm.Parameters.AddWithValue("@price", prd_info.price);
        cm.Parameters.AddWithValue("@stock", prd_info.stock);
        cm.Parameters.AddWithValue("@comment", prd_info.comment);
        cm.Parameters.AddWithValue("@pc_id", prd_info.pc_id);
        connection.set_connection();
        cm.ExecuteNonQuery();
    }

    // Searching by name
    public DataTable search_by_name(string prd_name)
    {
        cm = new SqlCommand("select * from product where name=@name", cn);  
        cm.Parameters.AddWithValue("@name", prd_name);
        dt = new DataTable(); 
        da = new SqlDataAdapter(cm);  
        da.Fill(dt);   
        return dt;
    }

    // Updating product info
    public void update(Product_info prd_info)
    {
        cm = new SqlCommand("update product set name = @name, date1 = @date1, price = @price, stock = @stock, comment = @comment, pc_id = @pc_id where pr_id=@pr_id", cn);
        cm.Parameters.AddWithValue("@pr_id", prd_info.pr_id);
        cm.Parameters.AddWithValue("@name", prd_info.name);
        cm.Parameters.AddWithValue("@date1", prd_info.date1);
        cm.Parameters.AddWithValue("@price", prd_info.price);
        cm.Parameters.AddWithValue("@stock", prd_info.stock);
        cm.Parameters.AddWithValue("@comment", prd_info.comment);
        cm.Parameters.AddWithValue("@pc_id", prd_info.pc_id);
        connection.set_connection();
        cm.ExecuteNonQuery();
    }

    // Deleting product
    public void delete(int prd_id)
    {
        cm = new SqlCommand("delete from product where pr_id=@pr_id", cn);
        cm.Parameters.AddWithValue("@pr_id", prd_id);
        connection.set_connection();
        cm.ExecuteNonQuery();
    }

    // Displaying all products
    public DataTable display()
    {
        cm = new SqlCommand("get_all_product", cn);  
        cm.CommandType = CommandType.StoredProcedure; 
        dt = new DataTable(); 
        da = new SqlDataAdapter(cm);  
        da.Fill(dt);   
        return dt;   
    }
}
