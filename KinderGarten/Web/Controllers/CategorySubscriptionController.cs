using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class CategorySubscriptionController : Controller
    {
        CategorySubscriptionService categorySubscriptionService = new CategorySubscriptionService();
        // GET: CategorySubscription
        public ActionResult Index()
        {
            return View(categorySubscriptionService.GetAll());
        }

        // GET: CategorySubscription/Details/5
        public ActionResult Details(int id)
        {
            CategorySubscription categorySubscription = categorySubscriptionService.getCategorySubscriptionById(id);
            if (categorySubscription != null)
            {
                return View(categorySubscription);
            }
            return View();
        }

        // GET: CategorySubscription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorySubscription/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description,Price")] CategorySubscription categorySubscription)
        {
            if (ModelState.IsValid)
            {
                if (categorySubscriptionService.Add(categorySubscription))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: CategorySubscription/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategorySubscription/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Description,Price")] CategorySubscription categorySubscription)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (categorySubscriptionService.Update(id, categorySubscription))
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

        // GET: CategorySubscription/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategorySubscription/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (categorySubscriptionService.deleteCategorySubscriptionById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}


