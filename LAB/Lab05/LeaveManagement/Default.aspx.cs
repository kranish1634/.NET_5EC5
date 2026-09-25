using System;
namespace Leave_Management
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = "Selected Date: " + Calendar1.SelectedDate.ToShortDateString();
            Session["LeaveDate"] = Calendar1.SelectedDate.ToShortDateString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Leave.aspx");
        }
    }
}
