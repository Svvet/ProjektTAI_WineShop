using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineShop.Models
{
    public class Position
    {
        public int Id { get; set; }
        public Wine PosWine { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
    }
}
