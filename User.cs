using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP_Assignment
{
    class User
    {
        private static string userID;
        private static string userFullName;
        private static string userRole;
        private static string email;

        //get and settors method for various private static strings for security purposes
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
        public string UserFullName
        {
            get { return userFullName; }
            set { userFullName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
