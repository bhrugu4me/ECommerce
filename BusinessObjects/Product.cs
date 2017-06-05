using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ActualImage { get; set; }
        public string CategaryId { get; set; }
        public string SubCategaryId { get; set; }

        public string CategaryName { get; set; }
        public string SubCategaryName { get; set; }

        public string Description { get; set; }
        public string SellerId { get; set; }
        public string SellerDescr { get; set; }
        public DateTime InsertedOn { get; set; }
        public string InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string requestedby { get; set; }


    }
}
