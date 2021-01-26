using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooKMyShowModel.DataModel
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        public int MovieID { get; set; }
        public int TheaterID { get; set; }
        public int ShiftID { get; set; }
        public int HallID { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowTiming { get; set; }
    }
}
