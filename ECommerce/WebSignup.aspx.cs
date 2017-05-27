using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceLayer;
using BusinessObjects;

namespace ECommerce
{
    public partial class WebSignup : System.Web.UI.Page
    {
        ClsUserType objtype = new ClsUserType();
        ClsUser objuser = new ClsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reset();
            }
        }

        public void reset()
        {
            fillusertype();
        }
        public void fillusertype()
        {
            List<UserType> usertype = new List<UserType>();
            usertype = objtype.AllUserType().Where(p => p.UserTypeId != 1).ToList();
            if (usertype.Count > 0)
            {
                ddlusertype.DataSource = usertype;
                ddlusertype.DataTextField = "UserTypeName";
                ddlusertype.DataValueField = "UserTypeId";
                ddlusertype.DataBind();
            }
            else
            {
                ddlusertype.DataSource = null;
                ddlusertype.DataBind();

            }
            ddlusertype.Items.Insert(0, new ListItem("<-- Select -->", ""));
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BusinessObjects.User user = new BusinessObjects.User();
                long ret = -1;
                user.FirstName = txtfirstname.Text;
                user.LastName = txtlastname.Text;
                user.Password = ClsUtility.MD5Hash(txtpassword.Text.Trim().ToString());
                user.EmailId = txtemailid.Text;
                user.MobileNo = txtmobileno.Text;
                user.Birthdate = Convert.ToDateTime(txtbirthdate.Text.ToString());
                user.UserTypeId = (ddlusertype.SelectedValue.ToString());
                user.Gender = rbgender.SelectedItem.Text;
                user.requestedBy = "0";
                ret = objuser.InsertUser(user);
                if (ret > 0)
                    Response.Redirect("VerifyUsers.aspx");
                else
                {
                    lblmsg.Text = "Registration failed, please try after sometime";
                }
            }
            //call insert user here


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

        }
    }
}