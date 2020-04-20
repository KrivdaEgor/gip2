using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Subjects
    {
        public Subjects()
        {
            Lectures = new HashSet<Lectures>();
        }

        public string IdSubject { get; set; }
        public string Name { get; set; }
        public int StudentPoints { get; set; }

        public virtual ICollection<Lectures> Lectures { get; set; }
    }
}
