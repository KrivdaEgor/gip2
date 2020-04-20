using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public partial class Users : IdentityUser
    {
        public Users()
        {
            LecturesPool = new HashSet<LecturesPool>();
        }

        public int IdGroup { get; set; }
        public int TypeUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Groups IdGroupNavigation { get; set; }
        public virtual ICollection<LecturesPool> LecturesPool { get; set; }
    }
}
