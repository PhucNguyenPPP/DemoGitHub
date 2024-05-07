using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ChatMessage
    {
        public Guid ChatId { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        // con dang ????
    }
}
