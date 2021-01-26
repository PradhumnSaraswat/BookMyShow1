using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooKMyShowModel.Models
{
    public class Show
    {
        public int Id { get; set; }
        public int MovieID { get; set; }
        public int TheaterID { get; set; }
        public int ShiftID { get; set; }
        public int HallID { get; set; }
        public DateTime ShowDate { get; set; }

        public string ShowTiming { get; set; }
    }
}
