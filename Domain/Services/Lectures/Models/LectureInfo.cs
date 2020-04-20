using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Lectures.Models
{
    public class LectureInfo
    {
        public int IdLecture { get; set; }
        public int IdClassRoom { get; set; }
        public string IdSubject { get; set; }
        public DateTime DateTime { get; set; }
    }
}
