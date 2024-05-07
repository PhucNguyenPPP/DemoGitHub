using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Feedback
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid FeedbackId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public string? Response { get; set; }
        public int? Reported { get; set; }
        public virtual User User { get; set; }
        public Guid? UserId { get; set; }
        public virtual Product Product { get; set; }
        public Guid? ProductId { get; set; }
    }
}
