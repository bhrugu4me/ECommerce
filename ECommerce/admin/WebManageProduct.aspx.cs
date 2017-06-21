using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using ServiceLayer;
using System.IO;

namespace ECommerce.Admin
{
    public partial class WebManageProduct : System.Web.UI.Page
    {
        ClsProduct objprod = new ClsProduct();
        ClsCategary objcat = new ClsCategary();
        //clsP
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                reset();
        }
        public void reset()
        {
            hdnid.Value = "0";
            fillgrid();
            txtpname.Text = "";
            txtdesc.Text = "";
            // fillparent();
            fillcat();
            fillseller();
            dvsubcat.Visible = false;
        }

        public void fillseller()
        {
            ClsUser objusr = new ClsUser();
            List<User> usrs = new List<BusinessObjects.User>();
            usrs = objusr.AllUsers().Where(p => p.UserTypeId.Equals("3")).ToList();
            if (usrs.Count > 0)
            {
                ddlsell.DataSource = usrs;
                ddlsell.DataTextField = "FirstName";
                ddlsell.DataValueField = "UserId";
                ddlsell.DataBind();

            }
            else
            {
                ddlsell.DataSource = null;
                ddlsell.DataBind();
            }
            ddlsell.Items.Insert(0, new ListItem("<-- Select -->", "0"));
            ddlsell.SelectedIndex = 0;
        }
        public void fillgrid()
        {
            List<Product> lstobj = objprod.ProductList();
            if (lstobj != null)
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

        public void fillcat()
        {
            List<Categary> lstobj = objcat.CategoryList().Where(p => p.ParentId.Equals("0")).ToList();
            if (lstobj != null)
            {
                ddlcat.DataSource = lstobj;
                ddlcat.DataTextField = "CategaryName";
                ddlcat.DataValueField = "CategaryId";
                ddlcat.DataBind();

            }
            else
            {
                ddlcat.DataSource = null;
                ddlcat.DataBind();

            }
            ddlcat.Items.Insert(0, new ListItem("<- Select ->", "0"));

        }



        protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcat.SelectedIndex > 0)
            {
                List<Categary> CatList = objcat.SubCategoryList(Convert.ToInt32(ddlcat.SelectedItem.Value));
                if (CatList.Count > 0)
                {
                    ddlsubcat.Visible = true;
                    if (CatList != null)
                    {
                        dvsubcat.Visible = true;
                        ddlsubcat.DataSource = CatList;
                        ddlsubcat.DataTextField = "CategaryName";
                        ddlsubcat.DataValueField = "CategaryId";
                        ddlsubcat.DataBind();

                    }
                    else
                    {
                        ddlsubcat.DataSource = null;
                        ddlsubcat.DataBind();

                    }
                    ddlsubcat.Items.Insert(0, new ListItem("<- Select ->", "0"));

                }
            }
            else
            {
                dvsubcat.Visible = false;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

            ClsProduct objprod = new ClsProduct();
            Product product = new Product();
            if (fuproduct.HasFile)
            {
                string strFileType = Path.GetExtension(fuproduct.FileName).ToLower();
                long retval = -1;
                string filename = (Session["uid"].ToString() + "_" + DateTime.Now.Ticks.ToString() + strFileType);
                string path = Server.MapPath("~/Images/Products/") + filename;
                string orignalfilename = fuproduct.PostedFile.FileName.ToString();
                string savepath = Server.MapPath("~/Images/Products/");

                fuproduct.SaveAs(path);
                product.ProductId = Convert.ToInt32(hdnid.Value);
                product.CategaryId = ddlcat.SelectedItem.Value;
                product.CategaryName = ddlcat.SelectedItem.Text;
                product.Description = txtdesc.Text;
                product.ProductName = txtpname.Text;
                product.SellerDescr = txtsdesc.Text;
                product.SellerId = ddlsell.SelectedItem.Value;
                product.SubCategaryId = dvsubcat.Visible ? ddlsubcat.SelectedItem.Value : "0";
                product.SubCategaryName = dvsubcat.Visible ? ddlsubcat.SelectedItem.Text : "";
                product.requestedby = Session["uid"].ToString();
                product.ProductImage = filename;
                product.ActualImage = orignalfilename;

                if (hdnid.Value.Equals("0"))
                {
                    retval = objprod.InsertProduct(product);
                    if (retval > 0)
                    {
                        lblmsg.Text = "Product Save Successfully";
                        reset();
                    }
                }
                else
                {
                    retval = objprod.UpdateProduct(product);
                    if (retval > 0)
                    {
                        lblmsg.Text = "Product update Successfully";
                        reset();
                    }
                }
            }
            
        }

      

    }
}