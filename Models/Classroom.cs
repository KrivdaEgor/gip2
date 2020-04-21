using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIP2LearnPlatform.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Resources { get; set; }
        public int Capacity { get; set; }
    }
}