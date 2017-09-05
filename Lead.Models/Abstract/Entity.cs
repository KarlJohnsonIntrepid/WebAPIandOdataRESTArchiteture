using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.Models.Abstract
{
    /// <summary>
    /// Marker Interface to denote a domain entity
    /// </summary>
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

