using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShippingServiceSeller
    {
        public Guid SsId { get; set; }
        public Guid UserId { get; set; }
        public virtual ShippingService ShippingService { get; set; }
        public virtual User Users { get; set; }
    }
}
