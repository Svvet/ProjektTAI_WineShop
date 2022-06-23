using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime RegisterTime { get; set; }
        public string DelieveryMethod { get; set; }
        public string Adress { get; set; }
        public string UserName { get; set; }
        public double Total { get; set; }
        public bool Realised { get; set; }
        public Basket OrderBasket { get; set; }
    }
}
