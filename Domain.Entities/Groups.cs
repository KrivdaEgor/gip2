using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Groups
    {
        public Groups()
        {
            Users = new HashSet<Users>();
        }

        public int IdGroup { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
