using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Entity;
using BLL;
using DAL;
using System.Data;
using System.IO;

namespace RealProjectB2.auth
{
    public partial class register : System.Web.UI.Page
    {
        AuthBLL objAuthUR = new AuthBLL();
        AuthDAL bjAuthDAL = new AuthDAL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlReligion, "select ReligionId,ReligionName from Conf_Religion", "ReligionName", "ReligionId");
               
            }
        }

        //private void ddlLoad()
        //{
        //    DataTable dt = new DataTable();
        //    dt = bjAuthDAL.ddlLoad("select ReligionId,ReligionName from Conf_Religion");
        //    ddlReligion.DataSource = dt;
        //    ddlReligion.DataTextField = "ReligionName";
        //    ddlReligion.DataValueField = "ReligionId";
        //    ddlReligion.DataBind();
        //    ListItem li = new ListItem("Select.....","0");
        //    ddlReligion.Items.Insert(0,li);

        //}
    
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                int result = SaveUReg();
                if (result > 0)
                {
                    ClearFieldValue();
                   

                }
                else
                {
                    
                }
            }    
           
        }
        #region Method
        private void ClearFieldValue()
        {
            txtuserName.Text = "";
            txtFirstName.Text = "";
            txtMidName.Text = "";
            txtLastName.Text = "";
            ddlGender.SelectedValue = "0";
            txtDateOfBirth.Text = "";

            flUserImage.PostedFile.InputStream.Dispose();
        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        private int SaveUReg()
        {
            int result = 0;
            EUserReg objEUser = new EUserReg();
            objEUser.UserName= txtuserName.Text.Trim();
            objEUser.Firstname = txtFirstName.Text.Trim();
            objEUser.MidleName = txtMidName.Text.Trim();
            objEUser.LastName = txtLastName.Text.Trim();
            objEUser.Gender = int.Parse(ddlGender.SelectedValue);
            objEUser.DateofBirth = txtDateOfBirth.Text;
            objEUser.ContactNo = txtContact.Text.Trim();
            objEUser.Email = txtEmail.Text.Trim();
            objEUser.Address = txtAddress.Text.Trim();
            objEUser.ReligionId = Convert.ToInt32(ddlReligion.SelectedValue);
            objEUser.UserImage = UserImage();
            result = objAuthUR.Insert_UserRegInfo(objEUser);
            return result;
        }

        private string UserImage()
        {
            string imagename = flUserImage.FileName;
            var FileExtension = Path.GetExtension(flUserImage.PostedFile.FileName).Substring(1);
            if (FileExtension == "jpg" || FileExtension == "png" || FileExtension == "jpeg")
            {
                flUserImage.SaveAs(Server.MapPath("~/assets/img/users/" + flUserImage.FileName));
            }
            return imagename;
        }
        private bool CheckFieldValue()
        {
            bool IsReq = false;

            string UserChk = objc.getString("select UserName from UserRegistration where UserName='"+txtuserName.Text+"'");

            if (txtuserName.Text == "")
            {
              
                txtuserName.Focus();
                IsReq = true;
            }
            else if (txtFirstName.Text == "")
            {
               
                txtFirstName.Focus();
                IsReq = true;
            }
            else if (txtLastName.Text == "")
            {
              
                txtLastName.Focus();
                IsReq = true;
            }
            else if (ddlGender.SelectedValue == "0")
            {
               
            }
            else if (UserChk !="")
            {
               
                IsReq = true;
            }


            return IsReq;

        }
        #endregion

       
    }
}