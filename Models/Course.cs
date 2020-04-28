using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIP2LearnPlatform.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int StudentPoints { get; set; }
        public string Users { get; set; }
    }
}