using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIP2.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public int RoomID { get; set; }

        public DateTime date { get; set;  } 
    }
}