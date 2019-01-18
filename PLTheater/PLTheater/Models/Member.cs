using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Contact { get; set; }

        [Required]
        [StringLength(20)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }


        [Required]
        public int GenderId { get; set; }


        public virtual Gender Gender { get; set; }

    }
}