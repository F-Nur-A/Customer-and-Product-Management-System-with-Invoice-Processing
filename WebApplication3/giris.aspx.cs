using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class giris : System.Web.UI.Page
    {

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("product.aspx");
        }
    }
}