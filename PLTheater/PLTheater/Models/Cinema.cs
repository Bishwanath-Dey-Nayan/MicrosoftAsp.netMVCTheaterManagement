using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [Range(30, 240)]
        public int Duration { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public string TrailerLink { get; set; }

        [Required]
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        [Required]

        public string IMDBLink { get; set; }


        public virtual ICollection<CinemaCasting> CinemaCasting { get; set; }

        public virtual ICollection<ShowTime> ShoeTimes { get; set; }

        public virtual ICollection<Poster> Posters { get; set; }



    }
}