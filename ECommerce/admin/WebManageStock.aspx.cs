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
    public partial class WebManageStock : System.Web.UI.Page
    {

        ClsStock objprod = new ClsStock();
        ClsStock objcat = new ClsStock();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                reset();
        }
        public void reset()
        {
            hdnid.Value = "0";
            
           
            // fillparent();
            fillproduct();
            //fillcstock();
          
          
        }

       
      

        public void fillproduct()
        {
            ClsProduct objproduct = new ClsProduct();
            List<Product> usrs = new List<BusinessObjects.Product>();
            usrs = objproduct.ProductList();
            if (usrs!= null)
            {
                ddlprod.DataSource = usrs;
               ddlprod.DataTextField = "ProductName";
               ddlprod.DataValueField = "ProductId";
                ddlprod.DataBind();

            }
            else
            {
                ddlprod.DataSource = null;
                ddlprod.DataBind();

            }
            ddlprod.Items.Insert(0, new ListItem("<- Select ->", "0"));

        }
        public void fillcstock(int id)
        {
            ClsStock objstock = new ClsStock();
            Stock obj = new Stock();
            //obj = objstock.
            if (ddlprod != null)
            {
               // txtcstock.Text = 
              txtcstock.Text = Convert.ToInt32(obj.ProductId).ToString();

            }  
        }
        public void fillcprice()
        {
            ClsStock objstock = new ClsStock();
            Stock obj = new Stock();
            //obj = objstock.
            if (ddlprod != null)
            {
                txtcprice.Text = Convert.ToInt32(obj.Price).ToString();
                //   txtcstock.Text = Convert.ToInt32(pd.ProductId).ToString();

            }
        }

        public void NewAvailStock()
        {
            if(Microsoft.VisualBasic.Information.IsNumeric(txtnewstck.Text))
                txtnasotck.Text = ( txtnewstck.Text + txtcstock.Text).ToString();
            else
            {
                lblmsg.Text = "Enter numeric value in new stock";
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ClsStock obst = new ClsStock();
            Stock st = new Stock();
            
            st.Quantity = txtnasotck.Text;
            st.Price = Convert.ToInt32(txtnprice.Text);
            st.ProductId = (ddlprod.Visible? ddlprod.SelectedItem.Value :"0");
            st.requestedby = Session["uid"].ToString();

            int ret = obst.InsertStock(st);
            if (ret > 0)
            {
                lblmsg.Text = "Data Save Successfully";
                reset();
            }

        }
       
      

        protected void btnreset_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void ddlprod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlprod.SelectedIndex>0)
                fillcstock(Convert.ToInt32(ddlprod.SelectedItem.Value.ToString()));
            fillcprice();
           
        }

        protected void txtnewstck_TextChanged(object sender, EventArgs e)
        {
            NewAvailStock();
        }
    }
}

