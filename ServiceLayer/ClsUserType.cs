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
public class ClsUserType
    {
        BLUserType objblutype = new BLUserType();

        public Int64 insertUType(UserType obj)
        {
            return objblutype.InsertUserType(obj);
        }

        public Int64 UpdateUType(UserType obj)
        {
            return objblutype.UpdateUserType(obj);
        }

        public Int64 DeleteUsType(UserType obj)
        {
            return objblutype.DeleteUserType(obj);
        }

        public UserType AllUserTypeById(UserType obj)
        {
            DataTable dt = new DataTable();
            dt = objblutype.GetAllUSerTypeById(obj);

            UserType retobj = new UserType();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    retobj.UserTypeId = Convert.ToInt32(dt.Rows[0]["UserTypeId"].ToString());
                    retobj.UserTypeName = dt.Rows[0]["UserTypeName"].ToString();
                    retobj.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                    retobj.InsertedOn = Convert.ToDateTime(dt.Rows[0]["InsertedOn"].ToString());
                    retobj.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[0]["UpdatedOn"].ToString());
                }
            }
            return retobj;
        }


        public List<UserType> AllUserType()
        {
            DataTable dt = new DataTable();
            dt = objblutype.GetAllUSerType();
            List<UserType> lstutype = new List<UserType>();
            UserType retobj;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retobj = new UserType();
                        retobj.UserTypeId = Convert.ToInt32(dt.Rows[i]["UserTypeId"].ToString());
                        retobj.UserTypeName = dt.Rows[i]["UserTypeName"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"].ToString());
                        retobj.InsertedBy = dt.Rows[i]["InsertedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"].ToString());
                        retobj.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        lstutype.Add(retobj);
                    }
                }
            }
            return lstutype;
         }
    }

}
