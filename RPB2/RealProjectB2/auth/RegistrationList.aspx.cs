using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace RealProjectB2.auth
{
    public partial class RegistrationList : System.Web.UI.Page
    {
        AuthBLL objAuthBLL = new AuthBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlReligion, "select ReligionId,ReligionName from Conf_Religion", "ReligionName", "ReligionId");
                LoadGridData();

            }
        }

        protected string BaseUrl(string url)
        {
            if (url != null)
            {
                url = "~/assets/img/users/" + url;
                return url;
            }
            else
            {
                return null;
            }

        }
        private void LoadGridData()
        {
            int religion = int.Parse(ddlReligion.SelectedValue);
            int gender = Convert.ToInt32(ddlGender.SelectedValue);
            DataTable dt = new DataTable();
            dt = objAuthBLL.GetUserRegList(religion, gender);

            if (dt.Rows.Count>0)
            {
                gvRegList.DataSource = dt;
                gvRegList.DataBind();
            }
            else
            {
                gvRegList.DataSource = null;
                gvRegList.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGridData();
        }

        protected void gvRegList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "approve")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                HiddenField hdnUserId = (HiddenField)gvRegList.Rows[rowIndex].Cells[0].FindControl("hdnUserId");

                string url = "UserApproval.aspx?param=" + hdnUserId.Value;
                string totalUrl = "var Mleft = (screen.width/2)-(800/2);var Mtop = (screen.height/2)-(500/2);window.open( '" + url + "', null, 'height=500,width=820,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", totalUrl, true);

            }
        }
    }
}