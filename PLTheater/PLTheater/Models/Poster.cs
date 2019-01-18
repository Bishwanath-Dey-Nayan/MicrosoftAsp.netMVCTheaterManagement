using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Poster
    {
        public int Id { get; set; }
        [Required]
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }
        public string Image { get; set; }

        [Required]
        public string Title { get; set; }
    }
}