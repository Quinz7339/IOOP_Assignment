using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace IOOP_Assignment
{
    public class Controllers
    {
        SqlConnection conn;
        SqlDataReader dr;
        // list of shared variables
        public static string getUserId(string userId)
        {
            return userId;
        }

    }

}
