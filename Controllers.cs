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
        public static string userID;
        public static string userName;

        public void Connect()
        {
            conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();
        }


        // return the status the authentication process, whether it is successful or failed
        public bool getUserId(string userId, string password)
        {
            //SQL commands for USER_PASSWORD_T for authentication purposes
            string cmdCheckPassword = "SELECT * FROM USER_PASSWORD_T WHERE userId = @usrId AND pwd= @pwd";

            Connect();
            SqlCommand cmd = new SqlCommand(cmdCheckPassword, conn);

            //concentate TextBox values to SQL string
            cmd.Parameters.AddWithValue("@usrId", userId);
            cmd.Parameters.AddWithValue("@pwd", password);

            SqlDataReader dr = cmd.ExecuteReader();

            //check if credentials entered is present in the database
            if (dr.Read())
            {
                userID = dr["userId"].ToString();
                getUserInfo(userID);
                conn.Close(); //closses the connection to SQL DB
                return true;
            }
            conn.Close(); //closses the connection to SQL DB
            return false;
        }

        public void getUserInfo(string userID)
        {
            string cmdGetUserInfo = "SELECT * FROM USER_INFO_T WHERE userId = @usrId";
            Connect();
            SqlCommand cmd = new SqlCommand(cmdGetUserInfo, conn);
            cmd.Parameters.AddWithValue("@usrId", userID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userName = dr["usrName"].ToString();
            }
        }

        //return status of adding reservation, either sucess or fail
        public int addReservation(string roomId, string bookingDate, string bookingTime, string reserveDate, string reserveStartTime, string reserveEndTime, string reserveStatus, string userId)
        {
            //SQL command to insert user's reservation info into the database table (RESERVATION_INFO_T)
            string insertSQL = "INSERT INTO RESERVATION_INFO_T(roomId, bookingDate, bookingTime, reserveDate, reserveStartTime, reserveEndTime, reserveStatus, userId) VALUES(@reserveID, @roomId, @bookingDate, @bookingTime, @reserveDate, @reserveStartTime, @reserveEndTime, @reserveStatus, @userId)";

            Connect();
            SqlCommand cmd = new SqlCommand(insertSQL, conn);

            //concentate TextBox values to SQL string
            cmd.Parameters.AddWithValue("@roomId", roomId);
            cmd.Parameters.AddWithValue("@bookingDate", bookingDate);
            cmd.Parameters.AddWithValue("@bookingTime", bookingTime);
            cmd.Parameters.AddWithValue("@reserveDate", reserveDate);
            cmd.Parameters.AddWithValue("@reserveStartTime", reserveStartTime);
            cmd.Parameters.AddWithValue("@reserveEndTime", reserveEndTime);
            cmd.Parameters.AddWithValue("@reservStatus", reserveStatus);
            cmd.Parameters.AddWithValue("@userId", userId);

            int status = cmd.ExecuteNonQuery(); //int is to check status success of faild the insert value
            conn.Close();
            return status;
        }



    }

}
