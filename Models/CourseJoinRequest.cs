using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIP2LearnPlatform.Models
{
    public class CourseJoinRequest
    {
        public int Id { get; set; }
        public string ApprovedByStudent { get; set; }
        public string ApprovedByTeacher { get; set; }
        public string User { get; set; }
        public string Course { get; set; }
    }
}