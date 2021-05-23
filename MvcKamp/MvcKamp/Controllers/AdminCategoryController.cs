using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()//ilk bunları ekledik
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p) //ilk bunları ekledik
        {
            CategoryValidator categoryValidator = new CategoryValidator();//control ettirmek için çağırdık
            ValidationResult results = categoryValidator.Validate(p); //burada fluent eklentisinden ekledik
            if (results.IsValid)//eğer kuralları geiçyorsa
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)//eğer kurallarda sıkıntı varsa 
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);//adı ve mesajı
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)//Manager dan geldik bu bir sayfa değilindex üzerinde çağıralarak kullanılacak
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryDelete(categoryValue);//manager ı doldurdaktan sonra burayageldik
            return RedirectToAction("Index");
        }
        //güncellenecek olan kategori yi bulmak lazım öncelikle
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetByID(id);//id değişkeninden gelen değere göre o satırı getirecek
            return View(categoryValue);//değişkenin içindeki değerle gidecek
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)//post edildğinde güncelleyecek değerlere göre
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}