using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.Models.Abstract;
using Lead.Models.Entities;

namespace Lead.Models.Models
{
    public class OrderModel : Entity
    {
        public string OrderName { get; set; }

        public VisitorModel Visitor { get; set; }
    }
}
