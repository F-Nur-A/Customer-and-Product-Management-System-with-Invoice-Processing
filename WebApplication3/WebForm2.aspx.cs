using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer_DAL cust_obj = new Customer_DAL();
            cust_obj.cn_open();
            GridView1.DataSource = cust_obj.disp();
            GridView1.DataBind();
        }
    }
}