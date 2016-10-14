using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465.WebForms
{
    public partial class Contact : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            uxEventOutput.Text += "OnInit";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            uxEventOutput.Text += " OnLoad";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            uxEventOutput.Text += " PreRender ";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<br />");
            builder.Append("Name: ");
            builder.Append(uxName.Text);
            builder.Append("<br />");

            builder.Append("Priority: ");
            builder.Append(uxPriority.Text);
            builder.Append("<br />");

            builder.Append("Subject: ");
            builder.Append(uxSubject.Text);
            builder.Append("<br />");

            builder.Append("Description: ");
            builder.Append(uxDescription.Text);
            builder.Append("<br />");

            uxFormOutput.Text = builder.ToString();
        }
    }
}