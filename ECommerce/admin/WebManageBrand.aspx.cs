using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using ServiceLayer;

namespace ECommerce.admin
{
    public partial class WebManageBrand : System.Web.UI.Page
    {
        ClsBrand objbrand = new ClsBrand();
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
            Fillgrid();
            txtbname.Text = "";
            txtdesc.Text = ""; 
            lblmsg.Text = "";
        }
        public void Fillgrid()
        {
            List<Brand> lstobj = objbrand.AllBrand();
            if (lstobj != null)
            {
                gvmanageBrand.DataSource = lstobj;
                gvmanageBrand.DataBind();
            }
            else
            {
                gvmanageBrand.DataSource = null;
                gvmanageBrand.DataBind();
                gvmanageBrand.EmptyDataText = "No Data Found";
            }
        }

        public void getdata(int id)
        {
            Brand obj = objbrand.AllBrandById(id);
            if (obj != null)
            {
                txtbname.Text = obj.BrandName;
                txtdesc.Text = obj.Description;
                hdnid.Value = obj.BrandId.ToString();
                dvgrid.Visible = false;
                btnsave.Text = "Update";
            }

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Brand obj = new Brand();
            obj.BrandId = Convert.ToInt32(hdnid.Value);
            obj.BrandName = txtbname.Text;
            obj.Description = txtdesc.Text;
            obj.requestedBy = Session["uid"].ToString();
            long ret = -1;
            if (hdnid.Value.Equals("0"))
                ret = objbrand.InsertBrand(obj);
            else
                ret = objbrand.UpdateBrandd(obj);
            if (ret > 0)
            {
                lblmsg.Text = hdnid.Value.Equals("0") ? "Data Saved Successfully" : "Data Updated Successfully";
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
            //Button btn = new Button();
            LinkButton btn = (LinkButton)sender; //Difference??
            getdata(Convert.ToInt32(btn.CommandArgument.ToString()));
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int ret = -1;
            ret = objbrand.DeleteBrand(Convert.ToInt32(btn.CommandArgument.ToString()));
            if (ret > 0)
            { 
                lblmsg.Text = "Data Deleted Successfully";
                lblmsg.ForeColor = System.Drawing.Color.DeepPink;
                lblmsg.Font.Bold = true;
                reset();
            }
            else
            {
                lblmsg.Text = "Data Removing failed";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Font.Bold = true;
            }
        }

    }
}