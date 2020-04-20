using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.ClassRooms.Models
{
    public class ClassRoomInfo
    {
        public int IdClassRoom { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Resource { get; set; }
    }
}
