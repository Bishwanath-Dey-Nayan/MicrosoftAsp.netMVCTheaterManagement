using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }


    }
}