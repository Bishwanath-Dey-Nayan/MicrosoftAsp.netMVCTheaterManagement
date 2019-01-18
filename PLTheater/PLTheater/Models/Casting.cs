using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Casting
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public int GenderId { get; set; }


        public virtual Gender Gender { get; set; }

        public virtual ICollection<CinemaCasting> CinemaCasting { get; set; }

    }
}