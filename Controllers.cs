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

        //be used by Login_Page at the runtime of the program
        //method to be called to update PENDING records that are before the current date and time to be REJECTED 
        public void preUpdateDatabase()
        {
            using (SqlConnection updateDBConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30 "))
            {
                updateDBConn.Open();
                string updateDBStr = "UPDATE RESERVATION_INFO_T SET reserveStatus = 'REJECTED' WHERE ((reserveDate <= @currentDate) AND (reserveStartTime < @currentTime)) AND (reserveStatus = 'PENDING')";
                using (SqlCommand updateDBCmd = new SqlCommand(updateDBStr, updateDBConn))
                {
                    string currentDate = DateTime.Today.ToString("yyyy-MM-dd");
                    string currentTime = DateTime.Now.ToString("hh:mm:ss tt");
                    string currentDateTime = currentDate + ' ' + currentTime;
                    updateDBCmd.Parameters.AddWithValue("@currentDate", currentDate);
                    updateDBCmd.Parameters.AddWithValue("@currentTime", DateTime.ParseExact(currentDateTime, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));

                    updateDBCmd.ExecuteNonQuery();
                }
            }
        }

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
                            User userInfo = new User();
                            userInfo.UserID = checkPasswordDr["userId"].ToString();
                            getUserInfo(userInfo.UserID);
                            return true;
                        }
                        return false;
                    }
                }
            }
        }

        private void getUserInfo(string userID)
        {
            User userInfo = new User();

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
                            userInfo.UserID = getUserInfoDr["userId"].ToString();
                            userInfo.UserFullName = getUserInfoDr["full_name"].ToString();
                            userInfo.UserRole = getUserInfoDr["user_role"].ToString();
                        }
                    }
                }
            }
        }
        //method to be used by studentResRoom to add reservation
        public string getUsableRoomId(string roomPrefix, string aSelectedDate, string aSelectedStartTime, string aSelectedEndTime)
        {
            //list to fill all the roomId(s) of a particular room type based on the selection made by the user
            List<string> roomIds = new List<string>();

            using (SqlConnection getRoomIdConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                getRoomIdConn.Open();
                string getRoomIdStr = "Select roomId FROM ROOM_INFO_T WHERE roomId LIKE @roomPrefix";
                using (SqlCommand getRoomIdCmd = new SqlCommand(getRoomIdStr, getRoomIdConn))
                {
                    getRoomIdCmd.Parameters.AddWithValue("@roomPrefix", roomPrefix + "%");

                    using (SqlDataReader getRoomIdReader = getRoomIdCmd.ExecuteReader())
                    {
                        //adds the roomIds from the ROOM_INFO_T table to the List <roomIds>
                        while (getRoomIdReader.Read())
                        {
                            roomIds.Add(getRoomIdReader[0].ToString());
                        }
                    }
                }
            }

            using (SqlConnection checkRoomConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                checkRoomConn.Open();
                string checkRoomStr = "SELECT roomId, reserveStartTime, reserveEndTime FROM RESERVATION_INFO_T WHERE roomId LIKE @roomPrefix AND reserveDate = @reserveDate AND (reserveStatus = 'PENDING' OR reserveStatus = 'APPROVED')";
                using (SqlCommand checkRoomCmd = new SqlCommand(checkRoomStr, checkRoomConn))
                {
                    checkRoomCmd.Parameters.AddWithValue("@roomPrefix", roomPrefix + "%");
                    checkRoomCmd.Parameters.AddWithValue("@reserveDate", aSelectedDate);

                    using (SqlDataReader checkRoomReader = checkRoomCmd.ExecuteReader())
                    {
                        while (checkRoomReader.Read())
                        {
                            //parsing the user selected times into datetime format
                            DateTime selectedStartTime = DateTime.ParseExact(aSelectedDate + ' ' + aSelectedStartTime, "yyyy-M-dd hh:mm tt", CultureInfo.InvariantCulture);
                            DateTime selectedEndTime = DateTime.ParseExact(aSelectedDate + ' ' + aSelectedEndTime, "yyyy-M-dd hh:mm tt", CultureInfo.InvariantCulture);

                            //parsing the datetime value of each reservations'(from the database) start time and end time into datetime format
                            DateTime recordStartTime = DateTime.Parse(checkRoomReader[1].ToString());
                            DateTime recordEndTime = DateTime.Parse(checkRoomReader[2].ToString());

                            //if either of this is true, where the user selected time intesects with any records' time, code blocks below is executed
                            if ((DateTime.Compare(selectedStartTime, recordStartTime) >= 0 && DateTime.Compare(selectedStartTime, recordEndTime) <= 0) || // Check if user selected start time is both (later than a record's start time ) AND (earlier than a record's end time)
                                (DateTime.Compare(selectedEndTime, recordStartTime) >= 0 && DateTime.Compare(selectedEndTime, recordEndTime) <= 0) || // Check if user selected endtime is both (later than a record's start time ) AND (earlier than a record's end time)
                                (DateTime.Compare(selectedStartTime, recordStartTime) <= 0 && DateTime.Compare(selectedEndTime, recordEndTime) >= 0)) // Check if user's (selected start time is earlier than a record's start time ) AND (selected end time later than a record's end time)
                            {

                                //loop to remove the roomId that intersects with the existing record from the List <roomIds>
                                //the List <roomIds> would only be filled with the valid roomIds to be used for reservation
                                for (int i = 0; i < roomIds.Count; i++)
                                {
                                    if (roomIds[i] == checkRoomReader[0].ToString())
                                    {
                                        roomIds.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return roomIds[0].ToString(); //return the 1st available roomId to the studentResRoom.cs form
        }

        //return the status of adding a reservation, either success or fail
        public int addReservation(string roomId, string bookingDate, string bookingTime, string reserveDate, string reserveStartTime, string reserveEndTime, string reserveStatus, string userId)
        {
            //SQL command to insert user's reservation info into the database table (RESERVATION_INFO_T)
            string addReservationStr = "INSERT INTO RESERVATION_INFO_T(roomId, bookingDate, bookingTime, reserveDate, reserveStartTime, reserveEndTime, reserveStatus, userId) VALUES (@roomId, @bookingDate, @bookingTime, @reserveDate, @reserveStartTime, @reserveEndTime, @reserveStatus, @userId)";

            using (SqlConnection addReservationConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                addReservationConn.Open();
                using (SqlCommand addReservationCmd= new SqlCommand(addReservationStr, addReservationConn))
                {

                    //formating the user selected reservation date together with their selected start time and selected endtime
                    string reserveStartTimeWithDate = reserveDate + " " + reserveStartTime;
                    string reserveEndTimeWithDate = reserveDate + " " + reserveEndTime;

                    //concentate TextBox values to SQL string
                    addReservationCmd.Parameters.AddWithValue("@roomId", roomId.Trim());
                    addReservationCmd.Parameters.AddWithValue("@bookingDate", DateTime.ParseExact(bookingDate, "dd/M/yyyy", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@bookingTime", DateTime.ParseExact(bookingTime, "hh:mm tt", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@reserveDate", DateTime.ParseExact(reserveDate, "yyyy-M-dd", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@reserveStartTime", DateTime.ParseExact(reserveStartTimeWithDate, "yyyy-M-dd hh:mm tt", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@reserveEndTime", DateTime.ParseExact(reserveEndTimeWithDate, "yyyy-M-dd hh:mm tt", CultureInfo.InvariantCulture));
                    addReservationCmd.Parameters.AddWithValue("@reserveStatus", "APPROVED");
                    addReservationCmd.Parameters.AddWithValue("@userId", userId);

                    //integer to be returned to be determined whether record has been added successfully or not
                    int status = addReservationCmd.ExecuteNonQuery(); 
                    return status; 
                }
            }
        }

        //method to be called by the btnSubmit_Click event at studentModRes to update the details of a modified room
        public int UpdateReserv(string roomId, string reserveId)
        {
            string updateResStr = "UPDATE RESERVATION_INFO_T SET roomId = @roomId, bookingDate = @date, bookingTime = @modTime, reserveStatus = 'PENDING'  WHERE reserveId = @reserveId";
            using (SqlConnection updateResConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                updateResConn.Open();
                using (SqlCommand updateResCmd = new SqlCommand(updateResStr, updateResConn))
                {
                    updateResCmd.Parameters.AddWithValue("@roomId", roomId);
                    updateResCmd.Parameters.AddWithValue("@date", DateTime.ParseExact(DateTime.Now.ToString("dd/M/yyyy"), "dd/M/yyyy", CultureInfo.InvariantCulture));
                    updateResCmd.Parameters.AddWithValue("@modTime", DateTime.ParseExact(DateTime.Now.ToString("hh:mm tt"), "hh:mm tt", CultureInfo.InvariantCulture));
                    updateResCmd.Parameters.AddWithValue("@reserveId", reserveId);

                    int status = updateResCmd.ExecuteNonQuery();
                    return status;
                }
            }
        }

        //method to be called by the btnSubmit_Click event at studentModRes to update the details of a modified room
        public int CancelReserv(string roomId, string reserveId)
        {
            string cancelResStr = "UPDATE RESERVATION_INFO_T SET reserveStatus = 'CANCELLED'  WHERE reserveId = @reserveId";
            using (SqlConnection cancelResConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                cancelResConn.Open();
                using (SqlCommand cancelResCmd = new SqlCommand(cancelResStr, cancelResConn))
                {
                    cancelResCmd.Parameters.AddWithValue("@roomId", roomId);
                    cancelResCmd.Parameters.AddWithValue("@reserveId", reserveId);

                    int status = cancelResCmd.ExecuteNonQuery();
                    return status;
                }
            }
        }
    }

}
