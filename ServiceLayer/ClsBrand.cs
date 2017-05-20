using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BusinessLayer;
using BusinessObjects;

namespace ServiceLayer
{
public class ClsBrand
    {
        BLBrand objblbrand = new BLBrand();

        public Int64 InsertBrand(Brand obj)
        {
            return objblbrand.InsertBrand(obj);
        }

        public Int64 UpdateBrandd(Brand obj)
        {
            return objblbrand.UpdateBrand(obj);
        }

        public Int64 DeleteBrand(int id)
        {
            return objblbrand.DeleteBrand(id);
        }
        public Brand AllBrandById(int id)
        {
            DataTable dt = new DataTable();
            dt = objblbrand.GetAllBrandById(id);

            Brand retobj = new Brand();
            if (dt != null)
            { 
                if (dt.Rows.Count > 0)
                {
                    retobj.BrandId = Convert.ToInt32(dt.Rows[0]["BrandId"].ToString());
                    retobj.BrandName = dt.Rows[0]["BrandName"].ToString();
                    retobj.Description = dt.Rows[0]["Description"].ToString();
                    retobj.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                    retobj.InsertedOn = Convert.ToDateTime(dt.Rows[0]["InsertedOn"].ToString());
                    retobj.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[0]["UpdatedOn"].ToString());
                }
            }
        return retobj;
        }

        public List<Brand> AllBrand()
        {
            DataTable dt = new DataTable();
            dt = objblbrand.GetAllBrand();
            List<Brand> lstBrand = new List<Brand>();
            Brand retobj;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retobj = new Brand();
                        retobj.BrandId = Convert.ToInt32(dt.Rows[i]["BrandId"].ToString());
                        retobj.BrandName = dt.Rows[i]["BrandName"].ToString();
                        retobj.Description = dt.Rows[i]["Description"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"].ToString());
                        retobj.InsertedBy = dt.Rows[i]["InsertedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"].ToString());
                        retobj.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        lstBrand.Add(retobj);
                    }
                }
            }
            return lstBrand;
        }
    }
}
