using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooKMyShowModel.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int ShowID { get; set; }
        public int SeatNumber { get; set; }
        public string UserName { get; set; }
    }
}
