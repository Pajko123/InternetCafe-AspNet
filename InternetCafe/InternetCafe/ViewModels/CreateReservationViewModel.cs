using InternetCafe.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetCafe.ViewModels
{
    [Authorize]
    public class CreateReservationViewModel
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

        public string VipRoom { get; set; }

        [Required]
        public string Customer { get; set; }

        public int DeviceId { get; set; }
        public int IRLId { get; set; }
        public int VIPId { get; set; }

        public List<Device> Devices { get; set; }
        public List<IRL> IRLs { get; set; }
        public List<VIP> VIPs { get; set; }
    }
}
