using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.Models.Abstract;
using Lead.Models.Entities;

namespace Lead.Models.Models
{
    public class VisitorModel :Entity
    {
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        public ICollection<OrderModel> Orders { get; set; }
    }
}
