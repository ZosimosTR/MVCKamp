using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFreamework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    public class IstatistikController : Controller
    {
        Context db = new Context();
       

        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.TopKategoriSayisi = db.Categories.Count();
            ViewBag.AolanYazarlar = db.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.yazilimBasliklari = db.Headings.Count(x => x.Category.CategoryId == 13);
            ViewBag.EnFazlaBaslik = db.Headings.Max(x => x.Category.CategoryName);
            ViewBag.TrueOlanlar = db.Categories.Count(x => x.CategoryStatus == true);
            ViewBag.FalseOlanlar = db.Categories.Count(x => x.CategoryStatus == false);


            return View();
  
        }
    }
}