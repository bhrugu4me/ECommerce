using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
  public  class UserType
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public DateTime InsertedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string InsertedBy { get; set; }
        public string requestedBy { get; set; }
    }
}
