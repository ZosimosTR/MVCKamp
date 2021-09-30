using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFreamework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        #region Kategori Ekleme

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        #endregion

    }
}