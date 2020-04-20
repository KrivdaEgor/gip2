using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ClassRooms
    {
        public ClassRooms()
        {
            Lectures = new HashSet<Lectures>();
        }

        public int IdClassRoom { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Resource { get; set; }

        public virtual ICollection<Lectures> Lectures { get; set; }
    }
}
