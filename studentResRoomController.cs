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
        public int addReservation(string roomId, string bookingDate, string bookingTime, string reserveDate, string reserveStartTime, string reserveEndTime, string reserveStatus, string userId)
        {
            string insertSQL = "INSERT INTO RESERVATION_INFO_T(roomId, bookingDate, bookingTime, reserveDate, reserveStartTime, reserveEndTime, reserveStatus, userId) VALUES(@reserveID, @roomId, @bookingDate, @bookingTime, @reserveDate, @reserveStartTime, @reserveEndTime, @reserveStatus, @userId)";

            Connect();
            SqlCommand cmd = new SqlCommand(insertSQL, conn);

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