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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());

        // GET: AdminCategory
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetById(id);
            return View(categoryValue);

        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            CategoryValidator catValidator = new CategoryValidator();
            ValidationResult results = catValidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }        

            return View();
        }
    }
}