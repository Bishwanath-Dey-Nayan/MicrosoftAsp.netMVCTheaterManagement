using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Producer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name="Producer Name")]
        public string Name { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}