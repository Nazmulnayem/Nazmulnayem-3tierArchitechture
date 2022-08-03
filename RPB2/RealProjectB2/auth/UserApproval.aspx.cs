using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Windows;

namespace RealProjectB2.auth
{
    public partial class UserApproval : System.Web.UI.Page
    {
        AuthBLL objAuthBll = new AuthBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnUpdateUserId.Value = Request.QueryString["param"].ToString();
                FillData(int.Parse(hdnUpdateUserId.Value));
            }
        }

        private void FillData(int Userid)
        {
            DataTable dt = new DataTable();
            dt = objAuthBll.GetUserRegList(0, 0, Userid);
            if (dt.Rows.Count>0)
            {
                txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                txtName.Text = dt.Rows[0]["Fullname"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                ddlAppSts.SelectedValue = dt.Rows[0]["AppStatus"].ToString();
            }


        }

        protected void ddlAppSts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAppSts.SelectedValue=="Approved")
            {
                divPassword.Visible = true;
            }
            else
            {
                divPassword.Visible = false;
            }
        }

        protected void bUpdate_Click(object sender, EventArgs e)
        {
           int ret= objAuthBll.Approved_UserRegInfo(int.Parse(hdnUpdateUserId.Value),ddlAppSts.SelectedValue,txtPassword.Text);
            if (ret>0)
            {
                MessageBox.Show("Update");
            }
        }
    }
}