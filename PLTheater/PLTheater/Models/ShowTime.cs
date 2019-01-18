using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class ShowTime
    {
        public int Id { get; set; }

        [Required]
        public int CinemaId { get; set; }

        public virtual Cinema Cinema {get;set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]
        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }


    }
}