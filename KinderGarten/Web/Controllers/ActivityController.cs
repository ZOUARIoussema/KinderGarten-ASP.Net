using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;


namespace Web.Controllers
{
    public class ActivityController : Controller
    {
        ActivityService activityService = new ActivityService();
        // GET: Activity
        public ActionResult Index()
        {
            return View(activityService.GetAll());
        }

        // GET: Activity/Details/5
        public ActionResult Details(int id)
        {
            Activity activity = activityService.getActivityById(id);
            if (activity != null)
            {
                return View(activity);
            }
            return View();
        }

        // GET: Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description,Photo")] Activity activity)
        {
            if (ModelState.IsValid) { 
                if (activityService.Add(activity))
            {
                return RedirectToAction("Index");
            }
            }
            return View();

        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Description,Photo")] Activity activity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (activityService.Update(id, activity))
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

        // GET: Activity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Activity/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (activityService.deleteActivityById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}


