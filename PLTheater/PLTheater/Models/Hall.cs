using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class Hall
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ACapacity { get; set; }
        public double APrice { get; set; }
        public string BCapacity { get; set; }
        public double BPrice { get; set; }
        
        public string CCapacity { get; set; }
        public double CPrice { get; set; }
        public string DCapacity { get; set; }
        public double DPrice { get; set; }

        public virtual ICollection<ShowTime> ShowTimes { get; set; }

    }
}