using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIP2LearnPlatform.Models
{
    public class CourseRequest
    {
        public int Id { get; set; }
        public string Course { get; set; }
        public string User { get; set; }
        public bool Approved { get; set; }
    }
}