using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    static class DBMethods
    {
        public static void RegisterNewUser(string login, string password, int access_type)
        {
            using(DBModelDataContext dc = new DBModelDataContext())
            {
                Users newuser = new Users() { USER_ID = Guid.NewGuid(), Name = login, Password = password, Access_type = access_type };
                dc.Users.InsertOnSubmit(newuser);
                dc.SubmitChanges();
            }
        }
        public static bool IsLoginExist(string login)
        {
            bool res = false;
            using (DBModelDataContext dc = new DBModelDataContext())
            {
                var qauth = from u in dc.Users
                            where u.Name == login
                            select u;
                if (qauth.Count() != 0) res = true;
            }
            return res;
        }
    }
}
