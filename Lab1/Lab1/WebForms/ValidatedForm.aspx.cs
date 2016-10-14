using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1.WebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append("?name=");
            queryString.Append(uxNameBox.Value);
            queryString.Append("&favoritecolor=");
            queryString.Append(uxColorBox.Value);
            queryString.Append("&city=");
            queryString.Append(uxCityBox.Value);

            Response.Redirect("ValidatedFormOutput.aspx" + queryString.ToString());
        }
    }
}