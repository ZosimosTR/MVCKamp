using BusinessLayer.Concrete;
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
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.TopKategoriSayisi = cm.GetList().Count().ToString();
            return View();
  
        }
    }
}