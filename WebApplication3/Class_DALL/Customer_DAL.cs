//using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data;// its required for ADO 
using System.Data.SqlClient;



class Customer_DAL
{

    SqlConnection cn;  //to connect to  a database
    SqlCommand cm;
    SqlDataAdapter da;
    DataTable dt;

    public Customer_DAL()
    {
        cn = connection.cn;
    }

    public DataTable disp()
    {
        
        cm = new SqlCommand("get_all_customer", cn);  
        dt = new DataTable();
        da = new SqlDataAdapter(cm);  
        da.Fill(dt);   
        cn.Close();    
        return (dt); 

    }

    public void cn_open()
    {
        cn = connection.cn;
        cn.Open();
    }

    public DataTable disp_tell()
    {
        cn.Open();  // for opening data base
        cm = new SqlCommand("get_all_cutometNameTell", cn);
        dt = new DataTable();
        da = new SqlDataAdapter(cm);
        da.Fill(dt);
        cn.Close();
        return (dt);
    }
    public void insert(customer_info obj1)
    {
        cn.Open(); 
        cm = new SqlCommand("Customer_insert", cn);
        cm.CommandType = CommandType.StoredProcedure;

        cm.Parameters.AddWithValue("@cu_id", obj1.cu_id);
        cm.Parameters.AddWithValue("@name", obj1.name);

        cm.Parameters.AddWithValue("@family", obj1.family);
        cm.Parameters.AddWithValue("@tell", obj1.tell);
        cm.Parameters.AddWithValue("@iban", obj1.iban);

        cm.ExecuteNonQuery();
        cn.Close(); // Bağlantıyı kapat
    }

    public void insert_json(string jsonstring)
    {
        cn.Open();
        customer_info obj1 = new customer_info();
        obj1 = JsonConvert.DeserializeObject<customer_info>(jsonstring);

        cm = new SqlCommand("insert into customer (cu_id, name, family, tell, iban) values (@cu_id, @name, @family, @tell, @iban)", cn);

        cm.Parameters.AddWithValue("@cu_id", obj1.cu_id);
        cm.Parameters.AddWithValue("@name", obj1.name);
        cm.Parameters.AddWithValue("@family", obj1.family);
        cm.Parameters.AddWithValue("@tell", obj1.tell);
        cm.Parameters.AddWithValue("@iban", obj1.iban);
        cm.ExecuteNonQuery();

        cn.Close();
    }
    public void update(customer_info obj1)
    {
        cm = new SqlCommand("update customer set  name = @name, family = @family, tell = @tell, iban = @iban where cu_id=@cu_id", cn);
        cm.Parameters.AddWithValue("@cu_id", obj1.cu_id);
        cm.Parameters.AddWithValue("@name", obj1.name);
        cm.Parameters.AddWithValue("@family", obj1.family);
        cm.Parameters.AddWithValue("@tell", obj1.tell);
        cm.Parameters.AddWithValue("@iban", obj1.iban);

        cm.ExecuteNonQuery();

        cn.Close();
    }
    public DataTable search_by_name(string name)
    {

        cm = new SqlCommand("search_customer_by_name", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cm.Parameters.AddWithValue("@name", name);

        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        cn.Close();
        return (dt);


    }
    public DataTable search_by_id(int id)
    {

        cm = new SqlCommand("search_customer_id", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cm.Parameters.AddWithValue("@cu_id", id);

        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        cn.Close();
        return (dt);


    }
    public DataTable search_by_familly(string family)
    {
        
        cm = new SqlCommand("search_customer_by_family", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cm.Parameters.AddWithValue("@family", family);

        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        cn.Close();
        return (dt);
    }
    public DataTable search_by_iban(string iban)
    {
        
        cm = new SqlCommand("customerSearchIban", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cm.Parameters.AddWithValue("@iban", iban);

        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        cn.Close();
        return (dt);
    }
    public DataTable search_by_tell(string tell)
    {
        
        cm = new SqlCommand("select * from customer where tell=@tell", cn);
        cm.Parameters.AddWithValue("@tell", tell);

        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        cn.Close();
        return (dt);
    }

    public void delete(int cu_id)
    {
        cm = new SqlCommand("delete from customer where cu_id=@cu_id", cn);
        cm.Parameters.AddWithValue("@cu_id", cu_id);

        cm.ExecuteNonQuery();

        cn.Close();
    }
}

