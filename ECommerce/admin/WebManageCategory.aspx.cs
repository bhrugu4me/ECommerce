using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using ServiceLayer;

namespace ECommerce.Admin
{
    public partial class WebManageCategory : System.Web.UI.Page
    {
        ClsCategary objcat = new ClsCategary();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                reset();
        }

        public void reset()
        {
            hdnid.Value = "0";
            fillgrid();
            txtcname.Text = "";
            txtdesc.Text = "";
            fillparent();
            dvgrid.Visible = true;
            lblmsg.Text = "";
        }

        public void fillgrid()
        {
            List<Categary> lstobj = objcat.CategoryList();
            if(lstobj!=null)
            {
                gvmanageproduct.DataSource = lstobj;
                gvmanageproduct.DataBind();

            }
            else
            {
                gvmanageproduct.DataSource = null;
                gvmanageproduct.DataBind();
                gvmanageproduct.EmptyDataText = "No Data Found";
            }
        }

        public void fillparent()
        {
            List<Categary> lstobj = objcat.CategoryList();
            if (lstobj != null)
            {
                ddlpcat.DataSource = lstobj;
                ddlpcat.DataTextField = "CategaryName";
                ddlpcat.DataValueField = "CategaryId";
                ddlpcat.DataBind();

            }
            else
            {
                ddlpcat.DataSource = null;
                ddlpcat.DataBind();
             }
            ddlpcat.Items.Insert(0, new ListItem("<- Select ->", "0"));
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Categary obj = new Categary();
            obj.CategaryId = Convert.ToInt32(hdnid.Value);
            obj.CategaryName = txtcname.Text;
            obj.Description = txtdesc.Text;
            obj.ParentId = ddlpcat.SelectedItem.Value;
            obj.PCatName = ddlpcat.SelectedItem.Text;
            obj.requestedby = Session["uid"].ToString();
            int ret = -1;
            if (hdnid.Value.Equals("0"))
                ret = objcat.InsertCategary(obj);
            else
                ret = objcat.UpdateCategary(obj);
            if(ret>0)
            {
                lblmsg.Text = hdnid.Value.Equals("0") ? "Data Save Successfully" : "Data Updated Successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Font.Bold = true;
                reset();
            }
            else
            {
                lblmsg.Text = "Data Saving Failed";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Font.Bold = true;

            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            getdata(Convert.ToInt32(btn.CommandArgument.ToString()));
        }

        public void getdata(int id)
        {
            Categary obj = objcat.CategoryById(id);
            if(obj!=null)
            {
                txtcname.Text = obj.CategaryName;
                txtdesc.Text = obj.Description;
                hdnid.Value = obj.CategaryId.ToString();
                dvgrid.Visible = false;
                ddlpcat.SelectedValue = obj.ParentId;
                btnsave.Text = "Update";
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ret = -1;
            ret = objcat.DeleteCategary(Convert.ToInt32(btn.CommandArgument.ToString()));
            if (ret > 0)
            {
                lblmsg.Text = "Data Removed Successfully";
                lblmsg.ForeColor = System.Drawing.Color.DeepPink;
                lblmsg.Font.Bold = true;
                reset();
            }
            else
            {
                lblmsg.Text = "Data Removing Failed";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Font.Bold = true;

            }
        }

        protected void gvmanageproduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmanageproduct.PageIndex = e.NewPageIndex;
            fillgrid();
        }
    }
}