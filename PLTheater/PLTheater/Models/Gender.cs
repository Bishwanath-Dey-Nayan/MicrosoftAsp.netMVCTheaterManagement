using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Gender")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public virtual ICollection<Casting> Castings { get; set; }

    }
}