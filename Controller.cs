using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IOOP_Assignment
{
    class Controller
    {
        public int updateDatabase(string reserveId, string userId, string roomId, string bookingDate, string bookingTime, string reserveDate, string reserveStartTime, string reserveEndTime, string approveOrReject)//int is to check status success of faild the insert value
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("Update RESERVATION_INFO_T SET reserveStatus=@status WHERE userId=@usrId AND reserveId=@resId AND roomId=@rmId AND bookingDate=@bookDate AND bookingTime=@bookTime AND reserveDate=@resDate AND reserveStartTime=@resStartTime AND reserveEndTime=@resEndTime", conn);

            cmd.Parameters.AddWithValue("@status", approveOrReject);
            cmd.Parameters.AddWithValue("@usrid", userId);
            cmd.Parameters.AddWithValue("@resid", reserveId);
            cmd.Parameters.AddWithValue("@rmid", roomId);
            cmd.Parameters.AddWithValue("@bookDate", DateTime.Parse(bookingDate));
            cmd.Parameters.AddWithValue("@bookTime", DateTime.Parse(bookingTime));
            cmd.Parameters.AddWithValue("@resDate", DateTime.Parse(reserveDate));
            cmd.Parameters.AddWithValue("@resStartTime", DateTime.Parse(reserveStartTime));
            cmd.Parameters.AddWithValue("@resEndTime", DateTime.Parse(reserveEndTime));
            int status = cmd.ExecuteNonQuery(); //int is to check status success of faild the insert value
            conn.Close();
            return status;
        }
    }
}
