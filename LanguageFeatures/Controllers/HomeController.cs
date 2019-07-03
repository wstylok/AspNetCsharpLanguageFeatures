using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();

            foreach(Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<brak>";
                string category = p?.Category ?? "<brak>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<brak>";
                string inStock = p?.InStock.ToString() ?? "<brak>";
                results.Add(string.Format($"Produkt: {name}, kategoria: {category}, cena: {price}, powiązanie: {relatedName}, w magazynie: {inStock}"));
            }

            return View(results);
        }
    }
}