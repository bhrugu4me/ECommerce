using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Categary
    {
        public int CategaryId { get; set; }
        public string CategaryName { get; set; }
        public string Description { get; set; }
        public string ParentId { get; set; }
        public string PCatName { get; set; }
        public DateTime InsertedOn { get; set; }
        public string InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string requestedby { get; set; }

    }
}
