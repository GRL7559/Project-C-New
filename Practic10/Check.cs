﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    internal class Check
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateOnly Date { get; set; }
        public bool PlMin { get; set; }
    }
}
