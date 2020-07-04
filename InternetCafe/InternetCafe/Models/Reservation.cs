using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetCafe.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End time")]
        public DateTime EndTime { get; set; }

        [Required]
        public string Customer { get; set; }
        public Device Device { get; internal set; }
        public VIP VIP { get; internal set; }
        public IRL IRL { get; internal set; }
    }
}
