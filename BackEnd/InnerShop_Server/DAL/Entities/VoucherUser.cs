using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class VoucherUser
    {
        public int Amount { get; set; }
        public virtual Voucher Voucher { get; set; }
        public Guid VoucherId { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
