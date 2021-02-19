using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;


namespace IOOP_Assignment
{
    class Controllers
    {
        public static string userID;
        public static string userName;
        public static string userRole;

        //to be used between Login_Page and the dashboard for both users
        // return the status the authentication process, whether it is successful or failed
        public bool getUserId(string userId, string password)
        {
            using (SqlConnection getUserIdConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30 "))
            {
                //SQL commands for USER_PASSWORD_T for authentication purposes
                string checkPasswordStr = "SELECT * FROM USER_PASSWORD_T WHERE userId = @usrId AND pwd = @pwd COLLATE SQL_Latin1_General_CP1_CS_AS";
                getUserIdConn.Open();
                using (SqlCommand checkPasswordCmd = new SqlCommand(checkPasswordStr, getUserIdConn))
                {
                    //concentate TextBox values to SQL string
                    checkPasswordCmd.Parameters.AddWithValue("@usrId", userId);
                    checkPasswordCmd.Parameters.AddWithValue("@pwd", password);

                    using (SqlDataReader checkPasswordDr = checkPasswordCmd.ExecuteReader())
                    {
                        //check if credentials entered is present in the database
                        if (checkPasswordDr.Read())
                        {
                            userID = checkPasswordDr["userId"].ToString();
                            getUserInfo(userID);
                            return true;
                        }
                        return false;
                    }
                }
            }
        }

        private void getUserInfo(string userID)
        {
            string cmdGetUserInfo = "SELECT * FROM USER_INFO_T WHERE userId = @usrId";
            using (SqlConnection getUserInfoConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                getUserInfoConn.Open();
                using (SqlCommand getUserInfoCmd = new SqlCommand(cmdGetUserInfo, getUserInfoConn))
                {
                    getUserInfoCmd.Parameters.AddWithValue("@usrId", userID);

                    using (SqlDataReader getUserInfoDr = getUserInfoCmd.ExecuteReader())
                    {
                        if (getUserInfoDr.Read())
                        {
                            userName = getUserInfoDr["usrName"].ToString();
                            userRole = getUserInfoDr["user_role"].ToString();
                        }
                    }
                }
            }
        }

        //return status of adding reservation, either success or fail
        public int addReservation(string roomId, string bookingDate, string bookingTime, string reserveDate, string reserveStartTime, string reserveEndTime, string reserveStatus, string userId)
        {
            //SQL command to insert user's reservation info into the database table (RESERVATION_INFO_T)
            string addReservationStr = "INSERT INTO RESERVATION_INFO_T(roomId, bookingDate, bookingTime, reserveDate, reserveStartTime, reserveEndTime, reserveStatus, userId) VALUES (@roomId, @bookingDate, @bookingTime, @reserveDate, @reserveStartTime, @reserveEndTime, @reserveStatus, @userId)";

            using (SqlConnection addReservationConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                addReservationConn.Open();
                using (SqlCommand addReservationCmd= new SqlCommand(addReservationStr, addReservationConn))
                {
                    //concentate TextBox values to SQL string
                    addReservationCmd.Parameters.AddWithValue("@roomId", roomId);
                    addReservationCmd.Parameters.AddWithValue("@bookingDate", DateTime.ParseExact(bookingDate, "dd/M/yyyy", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@bookingTime", DateTime.ParseExact(bookingTime, "hh:mm tt", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@reserveDate", DateTime.ParseExact(reserveDate, "dd/M/yyyy", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@reserveStartTime", DateTime.ParseExact(reserveStartTime, "hh:mm tt", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@reserveEndTime", DateTime.ParseExact(reserveEndTime, "hh:mm tt", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@reserveStatus", "APPROVED");
                    addReservationCmd.Parameters.AddWithValue("@userId", userId);


                    int status = addReservationCmd.ExecuteNonQuery(); //int is to check status success of faild the insert value
                    return status;
                }
            }
        }
        


    }

}
