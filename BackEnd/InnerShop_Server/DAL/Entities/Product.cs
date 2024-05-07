using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string? Description {  get; set; }
        public string? Branch { get; set; }
        public string? Origin { get; set; }
        public double? Size { get; set; }
        public int? Amount { get; set; }
        public bool Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual User User { get; set; }
        public Guid? UserId { get; set; }
        public virtual Category Category { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
