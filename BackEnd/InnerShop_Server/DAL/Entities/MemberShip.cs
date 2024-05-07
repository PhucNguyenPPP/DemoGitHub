using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MemberShip
    {
        public Guid MemberShipId { get; set; }
        [Required(ErrorMessage = "Rank is required")]
        public string Rank { get; set; }
        [Required(ErrorMessage = "Condition is required")]
        public double Condition { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}