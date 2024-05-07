using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CartProduct
    {
        [Required]
        public Guid CartId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Amount Of Product is required")]
        public int AmountOfProduct { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
