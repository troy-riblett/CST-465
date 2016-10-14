using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1.WebForms
{
    public partial class ValidatedFormOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["name"] != null &&
               Request.QueryString["favoritecolor"] != null &&
               Request.QueryString["city"] != null)
            {
                uxNameLiteral.Text = Request.QueryString["name"];
                uxFavoriteColorLiteral.Text = Request.QueryString["favoritecolor"];
                uxCityLiteral.Text = Request.QueryString["city"];
                uxValidDataArea.Visible = true;
            }
            else
            {
                uxInvalidDataArea.Visible = true;
            }
        }
    }
}