using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IOOP_Assignment
{
    class studentResRoomController
    {
        SqlConnection conn;

        public void Connect()
        {
            conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();

        }

        //int is to check status success of faild the insert value
        public int addReservation(string userID, string resRoomID, string resRoomType, string resDate, string resStartTime, string resEndTime, string currentDate, string currentTime)
        {
            string insertSQL = "INSERT INTO RESERVATION_INFO_T(reserveId, roomId, bookingDate, bookingTime, reserveDate, reserveStartTime, reserveEndTime, reservStatus, userID) VALUES(@reserveID, @roomID, @resRoomType, @resDate, @resStartTime, @resEndTime, @currentDate, @currentTime)";

            Connect();
            SqlCommand cmd = new SqlCommand(insertSQL, conn);

            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@fullname", std.Fullname);
            cmd.Parameters.AddWithValue("@phone", std.PhoneNumber);
            cmd.Parameters.AddWithValue("@course", std.Course);
            int status = cmd.ExecuteNonQuery(); //int is to check status success of faild the insert value
            conn.Close();
            return status;
        }
    }
}