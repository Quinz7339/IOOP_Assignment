using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP_Assignment
{
    class resRoom
    {
        private string userID;
        private string resRoomID;
        private string resRoomType;
        private string resDate;
        private string resStartTime;
        private string resEndTime;
        private string currentDate;
        private string currentTime;

        public resRoom(string userID,  string resRoomID, string resRoomType, string resDate, string resStartTime, string resEndTime, string currentDate, string currentTime)
        {
            this.userID = userID;
            this.resRoomID = resRoomID;
            this.resRoomType = resRoomType;
            this.resDate = resDate;
            this.resStartTime = resStartTime;
            this.resEndTime = resEndTime;
            this.currentDate = currentDate;
            this.currentTime = currentTime;
        }

        public string UserID { get => userID; set => userID = value; }
        public string ResRoomID { get => resRoomID; set => resRoomID = value; }
        public string ResRoomType { get => resRoomType; set => resRoomType = value; }
        public string ResDate { get => resDate; set => resDate = value; }
        public string ResStartTime { get => resStartTime; set => resStartTime = value; }
        public string ResEndTime { get => resEndTime; set => resEndTime = value; }
        public string CurrentDate { get => currentDate; set => currentDate = value; }
        public string CurrentTime { get => currentTime; set => currentTime = value; }
    }
}
