using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}