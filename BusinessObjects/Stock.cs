using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Stock
    {
        public int StockId { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertedOn { get; set; }
        public string InsertedBy { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string requestedby { get; set; }

    }
}
