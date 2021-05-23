using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class IstatistikController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var toplamSayi = _context.Categories.Count(); 
            ViewBag.mission1 = toplamSayi;

            var yazilimBaslik = _context.headings.Count(x => x.CategoryID == 14); 
            ViewBag.mission2 = yazilimBaslik;

            var icindeAYazar = _context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.mission3 = icindeAYazar;

            var maxBaslikliKategori = _context.headings.Max(x => x.Category.CategoryName); 
            ViewBag.mission4 = maxBaslikliKategori;

            var durumFark = (_context.Categories.Count(x => x.CategoryStatus == true))- (_context.Categories.Count(x => x.CategoryStatus == false)); // Kategoriler tablosundaki aktif kategori sayisi
            ViewBag.mission5 = durumFark;
            return View();
        }
    }
}