using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Lectures
    {
        public Lectures()
        {
            LecturesPool = new HashSet<LecturesPool>();
        }

        public int IdLecture { get; set; }
        public int IdClassRoom { get; set; }
        public string IdSubject { get; set; }
        public DateTime DateTime { get; set; }

        public virtual ClassRooms IdClassRoomNavigation { get; set; }
        public virtual Subjects IdSubjectNavigation { get; set; }
        public virtual ICollection<LecturesPool> LecturesPool { get; set; }
    }
}
