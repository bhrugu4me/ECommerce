using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceLayer;
using BusinessObjects;
namespace ECommerce.admin
{
    public partial class WebUserProfile : System.Web.UI.Page
    {
        ClsUserType objusertype = new ClsUserType();
        ClsUser objuser = new ClsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillusertype();
                filldata();
            }
        }
        public void reset()
        {
            hdnid.Value = "0";
            txtfirstName.Text = "";
            txtlastname.Text = "";
            txtmobileno.Text = "";
          //  rbgender
            txtemailid.Text = "";
            txtbirthdate.Text = "";
            lblmsg.Text = "";
        }
        public void fillusertype()
        {
            List<UserType> usertype = new List<UserType>();
            usertype = objusertype.AllUserType();
                //.Where(p => p.UserTypeId != 1).ToList();
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
        }
        private void filldata()
        {
            BusinessObjects.User user = new BusinessObjects.User();
            user.UserId = Convert.ToInt64(Session["uid"]);
            user = objuser.AllUserById(user);

            if (user.UserId != 0)
            {
                txtfirstName.Text = user.FirstName;
                txtlastname.Text = user.LastName;
                txtmobileno.Text = user.MobileNo;
                txtemailid.Text = user.EmailId;
                txtbirthdate.Text = user.Birthdate.ToString();
                ddlusertype.SelectedValue  = user.UserTypeId;
                if (user.Gender == "Male")
                    rbgender.Items[0].Selected = true;
                else
                    rbgender.Items[1].Selected = true;

            }

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BusinessObjects.User user = new BusinessObjects.User ();
                long ret = -1;
                user.FirstName = txtfirstName.Text;
                user.LastName = txtlastname.Text;
                user.EmailId = txtemailid.Text;
                user.MobileNo = txtmobileno.Text;
                user.Birthdate =  Convert.ToDateTime(txtbirthdate.Text);
                user.Gender = rbgender.SelectedItem.Text;
                user.UserId = Convert.ToInt64( Session["uid"]);
                user.UserTypeId = ddlusertype.SelectedValue;
                ret = objuser.Updateuser(user);
                if (ret > 0)
                    Response.Redirect("#");
                else
                {
                    lblmsg.Text = "Profile update failed, please try after sometime";
                }
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}