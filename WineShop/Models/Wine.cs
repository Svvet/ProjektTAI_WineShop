using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineShop.Models
{
    public class Wine
    {
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Color { get; set; }
        public string Flavour { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
        public double Alcohol { get; set; }
    }
}
