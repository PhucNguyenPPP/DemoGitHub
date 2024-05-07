using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShippingServiceCity
    {
        public Guid SsCityId {  get; set; }
        public string Type { get; set; }
        public double Price {  get; set; }
        [Required(ErrorMessage = "City is required")]
        public string CityId { get; set; }
        public virtual ShippingService ShippingService { get; set; }
        public Guid? SsId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
