using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Event_Registration_Portal
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Registration Successful!";

                lblSummary.Text =
                    "<div style='width:600px;margin:20px auto;padding:15px;" +
                    "border:2px solid green;background:#f0fff0;" +
                    "border-radius:8px;text-align:left;'>" +

                    "<h3 style='color:green;text-align:center;'>Registration Summary</h3>" +

                    "<b>Name:</b> " + TextBox1.Text + "<br/><br/>" +
                    "<b>Enrollment No:</b> " + TextBox2.Text + "<br/><br/>" +
                    "<b>Gender:</b> " + RadioButtonList1.SelectedItem.Text + "<br/><br/>" +
                    "<b>Branch:</b> " + DropDownList1.SelectedItem.Text + "<br/><br/>" +
                    "<b>Semester:</b> " + DropDownList3.SelectedItem.Text + "<br/><br/>" +
                    "<b>Email:</b> " + TextBox3.Text + "<br/><br/>" +
                    "<b>Mobile No:</b> " + TextBox4.Text + "<br/><br/>" +
                    "<b>Event:</b> " + DropDownList2.SelectedItem.Text +
                    "</div>";
            }
        }
    }
}