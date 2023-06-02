using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1semesterprojektdrengegruppen.Models
{
    internal class Product
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public double GrossPrice { get; set; }
        public int Qty { get; set; }
    }
}
