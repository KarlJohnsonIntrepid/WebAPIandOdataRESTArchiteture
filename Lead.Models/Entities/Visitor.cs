using Lead.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.Models.Entities
{
    /// <summary>
    /// This class represents the main table in the visitor database
    /// </summary>
    public class Visitor : Entity
    {
        [MaxLength(10)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
}
