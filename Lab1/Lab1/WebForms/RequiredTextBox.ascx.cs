using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1.WebForms
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public String LabelText
        {
            get { return uxLabel.Text; }
            set { uxLabel.Text = value; }
        }
        public String Value
        {
            get { return uxTextBox.Text; }
            set { uxTextBox.Text = value; }
        }

        public String ValidationGroup
        {
            get { return uxValidator.ValidationGroup; }
            set { uxValidator.ValidationGroup = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}