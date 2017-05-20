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
    public class ClsUser
    {
        BLUser objbluser = new BLUser();
        public Int64 InsertUser(User obj)
        {
            return objbluser.InsertUser(obj);
        }

        public Int64 Updateuser(User obj)
        {
            return objbluser.UpdateUser(obj);
        }

        public Int64 DeleteUser(User obj)
        {
            return objbluser.DeleteUserByUserID(obj);
        }

        public User CheckLogin(User obj)
        {
            DataTable dt = new DataTable();
            dt = objbluser.CheckLogin(obj);
            User retobj = new User();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    retobj.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                    retobj.FirstName = dt.Rows[0]["FirstName"].ToString();
                    retobj.LastName = dt.Rows[0]["LastName"].ToString();
                    retobj.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                    retobj.InsertedOn = Convert.ToDateTime(dt.Rows[0]["InsertedOn"].ToString());
                    retobj.MobileNo = dt.Rows[0]["ContactNo"].ToString();
                    //retobj.Password = dt.Rows[0]["Password"].ToString();
                    retobj.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[0]["UpdatedOn"].ToString());
                    retobj.UserTypeId = dt.Rows[0]["UserTypeId"].ToString();
                    retobj.Age = Convert.ToInt32(dt.Rows[0]["Age"].ToString());
                    retobj.Gender = dt.Rows[0]["Gender"].ToString();
                    retobj.Birthdate = Convert.ToDateTime(dt.Rows[0]["BirthDate"].ToString());
                    retobj.EmailId = dt.Rows[0]["EmailId"].ToString();
                    retobj.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"].ToString());

                }
            }
            return retobj;

        }


        public User AllUserById(User obj)
        {
            DataTable dt = new DataTable();
            dt = objbluser.GetUserDetailByUserID(obj);
            User retobj = new User();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    retobj.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                    retobj.FirstName = dt.Rows[0]["FirstName"].ToString();
                    retobj.LastName = dt.Rows[0]["LastName"].ToString();
                    retobj.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                    retobj.InsertedOn = Convert.ToDateTime(dt.Rows[0]["InsertedOn"].ToString());
                    retobj.MobileNo = dt.Rows[0]["ContactNo"].ToString();
                    retobj.Password = dt.Rows[0]["Password"].ToString();
                    retobj.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[0]["UpdatedOn"].ToString());
                    retobj.UserTypeId = dt.Rows[0]["UserTypeId"].ToString();
                    retobj.Age = Convert.ToInt32(dt.Rows[0]["Age"].ToString());
                    retobj.Gender = dt.Rows[0]["Gender"].ToString();
                    retobj.Birthdate = Convert.ToDateTime(dt.Rows[0]["BirthDate"].ToString());
                    retobj.EmailId = dt.Rows[0]["EmailId"].ToString();
                    retobj.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"].ToString());

                }
            }
            return retobj;

        }


        public List<User> AllUsers()
        {
            DataTable dt = new DataTable();
            dt = objbluser.GetAllUsers();
            List<User> lstusrs = new List<User>();
            User retobj;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retobj = new User();
                        retobj.UserId = Convert.ToInt32(dt.Rows[i]["UserId"].ToString());
                        retobj.FirstName = dt.Rows[i]["FirstName"].ToString();
                        retobj.LastName = dt.Rows[i]["LastName"].ToString();
                        retobj.InsertedBy = dt.Rows[i]["InsertedBy"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"].ToString());
                        retobj.MobileNo = dt.Rows[i]["ContactNo"].ToString();
                        //retobj.Password = dt.Rows[i]["Password"].ToString();
                        retobj.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"].ToString());
                        retobj.UserTypeId = dt.Rows[i]["UserTypeId"].ToString();
                        retobj.Age = Convert.ToInt32(dt.Rows[i]["Age"].ToString());
                        retobj.Gender = dt.Rows[i]["Gender"].ToString();
                        retobj.Birthdate = Convert.ToDateTime(dt.Rows[i]["BirthDate"].ToString());
                        retobj.EmailId = dt.Rows[i]["EmailId"].ToString();
                        retobj.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"].ToString());
                        lstusrs.Add(retobj);
                    }

                }
            }
            return lstusrs;

        }

        public List<User> ActiveUsers()
        {
            List<User> lstusrs = new List<User>();
            lstusrs = AllUsers().Where(p => p.IsActive == 1).ToList();
            return lstusrs;
        }

        public List<User> InActiveusers()
        {
            List<User> lstusrs = new List<User>();
            lstusrs = AllUsers().Where(p => p.IsActive == 0).ToList();
            return lstusrs;
        }
    }

}
