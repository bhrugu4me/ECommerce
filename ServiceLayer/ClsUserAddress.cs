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
    public class ClsUserAddress
    {
        BLUserAddress objbluseraddr = new BLUserAddress();

        public Int64 InsertUserAddress(UserAddress obj)
        {
            return objbluseraddr.InsertUserAddress(obj);
        }

        public Int64 UpdateUseraddr(UserAddress obj)
        {
            return objbluseraddr.UpdateUserAddress(obj);
        }

        public Int64 DeleteUseraddr(UserAddress obj)
        {
            return objbluseraddr.DeleteUserAddressByUserId(obj);
        }

        public UserAddress AllUserAddrById(UserAddress obj)
        {

            DataTable dt = new DataTable();
            dt = objbluseraddr.GetUserAddressByUserID(obj);

            UserAddress retobj = new UserAddress();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    retobj.AddressId = Convert.ToInt32( dt.Rows[0]["AddressId"].ToString());
                    retobj.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                    retobj.AddressType = dt.Rows[0]["AddressType"].ToString();
                    retobj.Address1 = dt.Rows[0]["Address1"].ToString();
                    retobj.Address2  = dt.Rows[0]["Address2"].ToString();
                    retobj.Landmark = dt.Rows[0]["Landmark"].ToString();
                    retobj.City = dt.Rows[0]["City"].ToString();
                    retobj.State = dt.Rows[0]["State"].ToString();
                    retobj.Country = dt.Rows[0]["Country"].ToString();
                    retobj.Pincode = dt.Rows[0]["Pincode"].ToString();
                    retobj.MobileNo = dt.Rows[0]["MobileNo"].ToString();
                }
            }
            return retobj;
        }
  }
}
