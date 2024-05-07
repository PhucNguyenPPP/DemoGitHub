using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        [Required(ErrorMessage = "Total Price is required")]
        public double TotalPrice { get; set; }
        public DateTime? OrderDate {  get; set; }
        public virtual User User { get; set; }
        public Guid? UserId { get; set; }
        public virtual Transaction Transaction { get; set; }
        //public Guid? TransactionId { get; set; }
        public virtual ShippingServiceCity ShippingServiceCity { get; set; }
        public Guid? SsCityId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
