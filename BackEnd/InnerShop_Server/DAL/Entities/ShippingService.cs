using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShippingService
    {
        public Guid SsId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public virtual ICollection<ShippingServiceSeller> ShippingServiceSellers { get; set; }
        public virtual ICollection<ShippingServiceCity> ShippingServiceCities { get; set; } 

    }
}
