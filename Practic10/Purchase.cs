using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    internal class Purchase
    {
        public List<CurrentProduct> Products { get; set; }
        public DateOnly Date {  get; set; }
        public double Amount { get; set; }
    }
}
