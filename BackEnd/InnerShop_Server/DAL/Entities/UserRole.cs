using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserRole
    {
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
