using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionInfo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public bool Status { get; set; }
        public virtual Order Order { get; set; }
        //public Guid? OrderId {  get; set; }
    }
}
