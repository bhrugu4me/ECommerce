using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using ServiceLayer;

namespace ECommerce
{
    public partial class WebLogin : System.Web.UI.Page
    {
        ClsUser objusr = new ClsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtunm.Focus();
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
              BusinessObjects.User user = new BusinessObjects.User();
                user.EmailId = txtunm.Text;
                user.Password = ClsUtility.MD5Hash(txtpwd.Text);
                user = objusr.CheckLogin(user);
                if (user.UserId == 0)
                {
                    lblmsg.Text = "Invalid UserName or Password, Please try again";
                    return;
                }
            else
            {
                Session["uid"] = user.UserId.ToString();
                Session["fullname"] = user.FirstName + user.LastName;
                if (user.UserTypeId.Equals("1"))
                {
                    Response.Redirect("Admin/WebAdminHome.aspx");
                }
                else if (user.UserTypeId.Equals("2"))
                {
                    Response.Redirect("Admin/WebSellerHome.aspx");
                }
                else if (user.UserTypeId.Equals("3"))
                {
                    Response.Redirect("Admin/WebClientHome.aspx");
                }

            }

        }
    }
}