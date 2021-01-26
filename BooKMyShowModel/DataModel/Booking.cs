using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooKMyShowModel.DataModel
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        public int ShowID { get; set; }
        public int SeatNumber { get; set; }
        public string UserName { get; set; }

    }
}
