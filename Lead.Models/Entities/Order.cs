using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.Models.Abstract;

namespace Lead.Models.Entities
{
    public class Order : Entity
    {
        public string OrderName { get; set; }

        public Visitor Visitor { get; set; }      
    }
}
