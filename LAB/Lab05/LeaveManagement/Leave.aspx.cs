using System;
namespace Leave_Management
{
    public partial class Leave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LeaveDate"] != null)
                {
                    txtLeaveDate.Text = Session["LeaveDate"].ToString();
                }
                if (Request.Cookies["EmpName"] != null)
                {
                    txtEmpName.Text = Request.Cookies["EmpName"].Value;
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (chkRemember.Checked)
            {
                Response.Cookies["EmpName"].Value = txtEmpName.Text;
                Response.Cookies["EmpName"].Expires = DateTime.Now.AddDays(7);
            }
            else
            {
                Response.Cookies["EmpName"].Expires = DateTime.Now.AddDays(-1);
            }
            // Success Message
            lblMsg.Text = "Leave Applied Successfully!";
            // Summary
            Label1.Text = "<br/><b>Leave Application Summary</b><br/><hr/>" +
                          "<b>Employee Name:</b> " + txtEmpName.Text + "<br/>" +
                          "<b>Leave Date:</b> " + txtLeaveDate.Text + "<br/>" +
                          "<b>Leave Type:</b> " + ddlLeaveType.SelectedItem.Text + "<br/>" +
                          "<b>Reason:</b> " + txtReason.Text;
        }
    }
}
