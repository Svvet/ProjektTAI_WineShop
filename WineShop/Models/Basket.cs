using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineShop.Models
{
    public class Basket
    {
        public Basket()
        {
            Positions = new List<Position>();
        }
        public int Id { get; set; }
        public List<Position> Positions { get; set; }
        public string User { get; set; }
        public bool Ordered { get; set; }
        public double Total { get; set; }

    }
}
