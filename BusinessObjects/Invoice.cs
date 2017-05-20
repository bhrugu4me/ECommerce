using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Invoice
    {
        public string InvoiceId { get; set; }
        public string OrderId { get; set; }
        public string FinalAmount { get; set; }
        public string AddressId { get; set; }
        public string EstimatedId { get; set; }
        public string PaymentMode { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public string UpdtedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string requestedby { get; set; }


    }
}
