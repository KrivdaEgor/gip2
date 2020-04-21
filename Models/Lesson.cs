using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIP2LearnPlatform.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public DateTime Time { get; set; }
        public string ClassroomId { get; set; }
    }
}