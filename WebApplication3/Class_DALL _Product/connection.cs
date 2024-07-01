using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;// the namespace for using ADO


    class connection
    {
    public static SqlConnection cn = new SqlConnection();
    static connection()
    {
        //the address of the data base in a connection string
        cn.ConnectionString = @"Data Source=DESKTOP-UAAQFE9\\SQLEXPRESS;Data Source=.;Integrated Security=SSPI;Initial Catalog=online_store";
    }
     public static void set_connection()
    {
        if (cn.State == ConnectionState.Closed)
            cn.Open();
    }
}

