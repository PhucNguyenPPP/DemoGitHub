using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Voucher
    {
        public Guid VoucherId { get; set; }
        [Required(ErrorMessage = "Voucher Name is required")]
        public string VoucherName { get; set;}
        public string? Description { get; set;}
        public bool Status { get; set;}
        public virtual MemberShip MemberShip { get; set;}
        public Guid MemberShipId { get; set; }
        public virtual ICollection<VoucherUser> VoucherUsers { get; set;}
    }
}
