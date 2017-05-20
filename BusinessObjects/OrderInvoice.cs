using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class OrderInvoice
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string SellerId { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string OthCharges { get; set; }
        public string ShippingCharges { get; set; }
        public string FinalAmount { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string requestedby { get; set; }

    }
}
