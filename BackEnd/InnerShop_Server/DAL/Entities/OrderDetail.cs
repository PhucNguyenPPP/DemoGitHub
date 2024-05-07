using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderDetail
    {
        [Required(ErrorMessage = "Amount of Product is required")]
        public int AmountProduct { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        public virtual Order Order { get; set; }
        public Guid? OrderId { get; set; }
        public virtual Product Product { get; set; }
        public Guid? ProductId { get; set; }
    }
}
