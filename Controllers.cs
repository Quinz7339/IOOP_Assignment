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
        public static string userID;
        public static string userName;
        public static string userRole;

        //to be used between Login_Page and the dashboard for both users
        // return the status the authentication process, whether it is successful or failed
        public bool getUserId(string userId, string password)
        {
            using (SqlConnection getUserIdConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                //SQL commands for USER_PASSWORD_T for authentication purposes
                string checkPasswordStr = "SELECT * FROM USER_PASSWORD_T WHERE userId = @usrId AND pwd= @pwd";
                getUserIdConn.Open();
                using (SqlCommand checkPasswordCmd = new SqlCommand(checkPasswordStr, getUserIdConn))
                {
                    //concentate TextBox values to SQL string
                    checkPasswordCmd.Parameters.AddWithValue("@usrId", userId);
                    checkPasswordCmd.Parameters.AddWithValue("@pwd", password);

                    SqlDataReader dr = checkPasswordCmd.ExecuteReader();

                    //check if credentials entered is present in the database
                    if (dr.Read())
                    {
                        userID = dr["userId"].ToString();
                        getUserInfo(userID);
                        return true;
                    }
                    return false;
                }
            }
        }

        public void getUserInfo(string userID)
        {
            string cmdGetUserInfo = "SELECT * FROM USER_INFO_T WHERE userId = @usrId";
            using (SqlConnection getUserInfoConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                getUserInfoConn.Open();
                using (SqlCommand getUserInfoCmd = new SqlCommand(cmdGetUserInfo, getUserInfoConn))
                {
                    getUserInfoCmd.Parameters.AddWithValue("@usrId", userID);
                    SqlDataReader dr = getUserInfoCmd.ExecuteReader();
                    if (dr.Read())
                    {
                        userName = dr["usrName"].ToString();
                        userRole = dr["user_role"].ToString();
                    }
                }
            }
        }

        //return status of adding reservation, either sucess or fail
        public int addReservation(string roomId, string bookingDate, string bookingTime, string reserveDate, string reserveStartTime, string reserveEndTime, string reserveStatus, string userId)
        {
            //SQL command to insert user's reservation info into the database table (RESERVATION_INFO_T)
            string addReservationStr = "INSERT INTO RESERVATION_INFO_T(roomId, bookingDate, bookingTime, reserveDate, reserveStartTime, reserveEndTime, reserveStatus, userId) VALUES(@reserveID, @roomId, @bookingDate, @bookingTime, @reserveDate, @reserveStartTime, @reserveEndTime, @reserveStatus, @userId)";

            using (SqlConnection addReservationConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                addReservationConn.Open();
                using (SqlCommand addReservationCmd= new SqlCommand(addReservationStr, addReservationConn))
                {
                    //concentate TextBox values to SQL string
                    addReservationCmd.Parameters.AddWithValue("@roomId", roomId);
                    addReservationCmd.Parameters.AddWithValue("@bookingDate", bookingDate);
                    addReservationCmd.Parameters.AddWithValue("@bookingTime", bookingTime);
                    addReservationCmd.Parameters.AddWithValue("@reserveDate", reserveDate);
                    addReservationCmd.Parameters.AddWithValue("@reserveStartTime", reserveStartTime);
                    addReservationCmd.Parameters.AddWithValue("@reserveEndTime", reserveEndTime);
                    addReservationCmd.Parameters.AddWithValue("@reserveStatus", "Approved");
                    addReservationCmd.Parameters.AddWithValue("@userId", userId);

                    int status = addReservationCmd.ExecuteNonQuery(); //int is to check status success of faild the insert value
                    return status;
                }
            }
        }
        


    }

}
