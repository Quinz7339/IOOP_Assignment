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
        // list of shared variables
        public static bool getUserId(string userId, string password)
        {
            //commands for USER_PASSWORD_T for authentication purposes
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM USER_PASSWORD_T WHERE userId = @usrId AND pwd= @pwd");
            conn.Open();

            //concentate TextBox values to SQL string
            cmd.Parameters.AddWithValue("@usrId", userId);
            cmd.Parameters.AddWithValue("@pwd", password);

            //establish cmd connection
            cmd.Connection = conn;
            SqlDataReader dr = cmd.ExecuteReader();

            //check if credentials entered is present in the database
            if (dr.HasRows)
            {
                conn.Close(); //closses the connection to SQL DB
                return true;
            }
            conn.Close(); //closses the connection to SQL DB
            return false;
        }

    }

}
