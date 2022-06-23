using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WineShop.Models
{
    public class WinesCModel
    {
        public List<Wine> Wines { get; set; }
        public string Sort { get; set; }
        public List<SelectListItem> CountryItems { get; set; }
        public List<SelectListItem> ColorItems { get; set; }
        public List<SelectListItem> FlavourItems { get; set; }
        public string Country { get; set; }
        public string Color { get; set; }
        public string Flavour { get; set; }

    }
}
