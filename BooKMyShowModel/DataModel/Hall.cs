﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooKMyShowModel.DataModel
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Totalseat { get; set; }

    }
}
