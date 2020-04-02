using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIP2.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string location { get; set; }
        public int capacity { get; set; }
        public string resourcesAvailable { get; set; } // vb. projector
    }
}