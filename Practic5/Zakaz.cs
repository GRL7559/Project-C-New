using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Practic5
{
    internal class Zakaz
    {
        public string Shape { get; set; }
        public string Size { get; set; }
        public string Taste { get; set; }
        public string Quantity { get; set; }
        public string Glaze { get; set; }
        public string Decor { get; set; }
        public int CostShape { get; set; }
        public int CostSize { get; set; }
        public int CostTaste { get; set; }
        public int CostQuantity { get; set; }
        public int CostGlaze { get; set; }
        public int CostDecor { get; set; }
        public Zakaz(string shape, string size, string taste, string quantity, string glaze , string decor , int costshape,int costsize, int costtaste, int costquantity, int costglaze, int costdecor)
        {
            Shape        = shape;
            Size         = size;
            Taste        = taste;
            Quantity     = quantity;
            Glaze        = glaze;
            Decor        = decor;
            CostShape    = costshape;
            CostSize     = costsize;
            CostTaste    = costtaste;
            CostQuantity = costquantity;
            CostGlaze    = costglaze;
            CostDecor    = costdecor;
        }
    }
    
}