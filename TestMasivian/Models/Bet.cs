﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMasivian.Models
{
    public class Bet : BaseEntity
    {
        public int RouletteId { set; get; }
        public string BetDate { get; set; }
        public int Amount { get; set; }
        public int Number { get; set; }
        public string Color { get; set; }
        
    }
}
