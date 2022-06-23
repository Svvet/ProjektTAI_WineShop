using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineShop.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WineShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WineShop.Controllers
{
    public class WineController : Controller
    {
        public IActionResult Index(string sort, string filterColor, string filterFlavour, string filterCountry)
        {
            WinesCModel model = new WinesCModel();
            model.Sort = sort;
            model.Color = filterColor;
            model.Flavour = filterFlavour;
            model.Country = filterCountry;
            using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                if (sort == null)
                {
                    model.Wines = context.Wines.ToList();
                }
                else
                {
                    switch (sort)
                    {
                        case "Price":
                            model.Wines = context.Wines.OrderBy(w => w.Price).ToList();
                            break;
                        case "Alcohol":
                            model.Wines = context.Wines.OrderBy(w => w.Alcohol).ToList();
                            break;
                        case "PriceDesc":
                            model.Wines = context.Wines.OrderByDescending(w => w.Price).ToList();
                            break;
                        case "AlcoholDesc":
                            model.Wines = context.Wines.OrderByDescending(w => w.Alcohol).ToList();
                            break;
                        default:
                            model.Wines = context.Wines.ToList();
                            break;
                    }
                }
                if (filterColor != null)
                {
                    model.Wines = model.Wines.FindAll(w => w.Color == filterColor);

                }
                if (filterFlavour != null)
                {
                    model.Wines = model.Wines.FindAll(w => w.Flavour == filterFlavour);

                }
                if (filterCountry != null)
                {
                    model.Wines = model.Wines.FindAll(w => w.Country == filterCountry);

                }
                List<string> Countries = context.Wines.Select(w => w.Country).Distinct().ToList();
                model.CountryItems = Countries.Select(c => new SelectListItem { Value = c, Text = c }).ToList();
                model.CountryItems.Insert(0, new SelectListItem { Value = "", Text = "" });
                List<string> Colors = context.Wines.Select(w => w.Color).Distinct().ToList();
                model.ColorItems = Colors.Select(c => new SelectListItem { Value = c, Text = c }).ToList();
                model.ColorItems.Insert(0, new SelectListItem { Value = "", Text = "" });
                List<string> Flavours = context.Wines.Select(w => w.Flavour).Distinct().ToList();
                model.FlavourItems = Flavours.Select(c => new SelectListItem { Value = c, Text = c }).ToList();
                model.FlavourItems.Insert(0, new SelectListItem { Value = "", Text = "" });
            }

            return View(model);

        }
        public IActionResult Details(int id)
        {
            WineCModel model = new WineCModel();
            using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                model.CWine = context.Wines.First(w => w.Id == id);

                //context.Orders.Add(orderTest);
                //context.SaveChanges();
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult AddPosition(WineCModel model)
        {
            
            Position newPos = new Position()
            {
                
                Number = model.Number
            };
            Basket newBasket;
            using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                Wine oldWine = context.Wines.Where(w => w.Id == model.CWine.Id).FirstOrDefault();
                newPos.PosWine = oldWine;
                newPos.Price = newPos.Number * oldWine.Price;
                var basket = context.Baskets.Include(b=>b.Positions).ThenInclude(p=>p.PosWine).Where(b => b.User == User.Identity.Name && b.Ordered == false).FirstOrDefault();
                if (basket == null)
                {
                    newBasket = new Basket()
                    {
                        Positions = new List<Position>()
                        {
                            newPos
                        },
                        User=User.Identity.Name,
                        Ordered = false,
                        Total = newPos.Price
                    };
                    
                    context.Baskets.Add(newBasket);
                    context.SaveChanges();
                }
                else
                {
                    
                    basket.Positions.Add(newPos);
                    basket.Total = basket.Total + newPos.Price;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Basket(int? id)
        {
            BasketCModel model = new BasketCModel();
            using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                if(id==null)
                    model.CBasket = context.Baskets.Include(b => b.Positions).ThenInclude(p => p.PosWine).
                    Where(b => b.User == User.Identity.Name && b.Ordered == false).FirstOrDefault();
                else
                    model.CBasket = context.Baskets.Include(b => b.Positions).ThenInclude(p => p.PosWine).
                    Where(b => b.Id==id).FirstOrDefault();
            }
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Order(BasketCModel model)
        {
            model.COrder.UserName = User.Identity.Name;
            model.COrder.RegisterTime = DateTime.Now;
            model.COrder.Realised = false;
            using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                Basket nowBasket = context.Baskets.Include(b => b.Positions).ThenInclude(p => p.PosWine).
                    Where(b => b.User == User.Identity.Name && b.Ordered == false).FirstOrDefault();
                nowBasket.Ordered = true;
                model.COrder.OrderBasket = nowBasket;
                double total = 0;
                foreach(var pos in nowBasket.Positions)
                {
                    total += pos.Price;
                }
                model.COrder.Total = total;
                context.Orders.Add(model.COrder);
                context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult Orders()
        {
            OrdersCModel model = new OrdersCModel();
            using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                model.Orders = context.Orders.Include(o => o.OrderBasket).Where(o => o.UserName == User.Identity.Name).ToList();
            }

                return View(model);
        }
        [HttpPost]
        public IActionResult DeletePos(int id)
        {
            using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                Position pos = context.Positions.Where(p => p.Id == id).FirstOrDefault();
                context.Positions.Remove(pos);
                context.SaveChanges();
            }
            return RedirectToAction("Basket");
        }
    }
}
