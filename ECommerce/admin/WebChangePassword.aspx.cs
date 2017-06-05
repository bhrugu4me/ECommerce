using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using ServiceLayer;
using System.Data;

namespace ECommerce.admin
{
    public partial class WebChangePassword : System.Web.UI.Page
    {
        ClsUser objusr = new ClsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reset();
            }

        }

        public void reset()
        {
            hdnid.Value = "0";
            txtcurrpwd.Text = "";
            txtnewpwd.Text = "";
            txtcurrpwd.Text = "";
            lblmsg.Text = "";
        }

       
        protected void lnkbtnsave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BusinessObjects.User user = new BusinessObjects.User();
                DataTable dt = new DataTable();
                int ret = -1;
                if (Session["Pwd"].ToString() != txtcurrpwd.Text)
                {
                    lblmsg.Text = "Please enter correct Current Password";
                }
                else
                {
                    user.Password = ClsUtility.MD5Hash(txtnewpwd.Text.Trim().ToString());
                    user.UserId = Convert.ToInt32(Session["Uid"].ToString());
                    dt = objusr.Changepwd(user);
                    if (dt != null)
                        lblmsg.Text = "password changed successfully";
                    else
                    {
                        lblmsg.Text = "can not change password";
                    }
                }

            }
        }

        protected void lnkbtnreset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}