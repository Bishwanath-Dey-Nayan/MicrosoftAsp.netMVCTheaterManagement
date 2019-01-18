using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class CinemaCasting
    {
        public int Id { get; set; }

        [Required]
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        [Required]
        public int CastingId { get; set; }

        public virtual Casting Casting { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}