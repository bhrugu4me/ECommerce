using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessLayer;
using System.Data;

namespace ServiceLayer
{
    public class ClsCategary
    {
        BLCategary objblcategary = new BLCategary();
        public int InsertCategary(Categary obj)
        {
            return objblcategary.InsertCategory(obj);
        }

        public int UpdateCategary(Categary obj)
        {
            return objblcategary.UpdateCategory(obj);
        }

        public int DeleteCategary(int id)
        {
            Categary obj = new Categary();
            obj.CategaryId = id;
            return objblcategary.DeleteCategory(obj);
        }


        public List<Categary> CategoryList()
        {
            DataTable dt = new DataTable();
            dt = objblcategary.GetAllCategory();
            List<Categary> lstcat = new List<Categary>();
            Categary retobj;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retobj = new Categary();
                        retobj.CategaryId = Convert.ToInt32(dt.Rows[i]["CategaryId"].ToString());
                        retobj.CategaryName = dt.Rows[i]["CategaryName"].ToString();
                        retobj.Description = dt.Rows[i]["Description"].ToString();
                        retobj.InsertedBy = dt.Rows[i]["InsertedBy"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"].ToString());
                        retobj.ParentId = dt.Rows[i]["ParentId"].ToString();
                        retobj.PCatName = dt.Rows[i]["ParentCategory"].ToString();
                        retobj.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"].ToString());
                        lstcat.Add(retobj);
                    }

                }
            }
            return lstcat;

        }


        public List<Categary> SubCategoryList(int CategoryId)
        {
            DataTable dt = new DataTable();
            Categary obj = new Categary();
            obj.CategaryId = CategoryId;
            dt = objblcategary.GetSubCategoryList(obj);
            List<Categary> lstcat = new List<Categary>();
            Categary retobj;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retobj = new Categary();
                        retobj.CategaryId = Convert.ToInt32(dt.Rows[i]["CategaryId"].ToString());
                        retobj.CategaryName = dt.Rows[i]["CategaryName"].ToString();
                        retobj.Description = dt.Rows[i]["Description"].ToString();
                        retobj.InsertedBy = dt.Rows[i]["InsertedBy"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"].ToString());
                        retobj.ParentId = dt.Rows[i]["ParentId"].ToString();
                        retobj.PCatName = dt.Rows[i]["ParentCategory"].ToString();
                        retobj.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"].ToString());
                        lstcat.Add(retobj);
                    }

                }
            }
            return lstcat;

        }


        public Categary CategoryById(int id)
        {
            Categary obj = new Categary();
            obj.CategaryId = id;
            DataTable dt = new DataTable();
            dt = objblcategary.GetCategoryDetailByID(obj);
            Categary retobj=new Categary();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                        retobj.CategaryId = Convert.ToInt32(dt.Rows[0]["CategaryId"].ToString());
                        retobj.CategaryName = dt.Rows[0]["CategaryName"].ToString();
                        retobj.Description = dt.Rows[0]["Description"].ToString();
                        retobj.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[0]["InsertedOn"].ToString());
                        retobj.ParentId = dt.Rows[0]["ParentId"].ToString();
                        retobj.PCatName = dt.Rows[0]["ParentCategory"].ToString();
                        retobj.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[0]["UpdatedOn"].ToString());
       
                }
            }
            return retobj;

        }
    }

}
