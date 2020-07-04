using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetCafe.Models
{
    public class VIP
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
