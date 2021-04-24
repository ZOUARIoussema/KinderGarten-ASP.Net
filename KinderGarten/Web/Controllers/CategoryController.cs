using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService;
        public CategoryController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            User usergarten = (User)System.Web.HttpContext.Current.Session["User"];

            categoryService = new CategoryService(token);
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(categoryService.GetAll());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Category category = categoryService.getCategoryById(id);
            if (category != null)
            {
                return View(category);
            }
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (categoryService.Add(category))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = categoryService.getCategoryById(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Description")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (categoryService.Update(id, category))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (categoryService.deleteCategoryById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}



