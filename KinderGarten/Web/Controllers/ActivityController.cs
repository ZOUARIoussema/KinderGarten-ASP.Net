using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;
using Service;


namespace Web.Controllers
{
    public class ActivityController : Controller
    {
        ActivityService activityService;
        KinderGartenService kinderGartenService;
        public ActivityController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            User usergarten = (User)System.Web.HttpContext.Current.Session["User"];

            activityService = new ActivityService(token);
            kinderGartenService = new KinderGartenService(token);
        }
        
        // GET: Activity
        public ActionResult Index()
        {
            return View(activityService.GetAll());
        }

        public ActionResult ActivityByKinderGarten()
        {
            KinderGarten k = kinderGartenService.findUserByIdK((int)Session["id"]);
            return View(activityService.ActivityByKinderGarten(k.Id));
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
        public ActionResult Create([Bind(Include = "Description,Photo")] Activity activity, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {
                activity.Photo = file.FileName;
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }


                KinderGarten k = kinderGartenService.findUserByIdK((int)Session["id"]);

                if (activityService.Add(activity, k.Id))
            {
                return RedirectToAction("Index");
            }
            }
            return View();

        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int id)
        {
            Activity activity = activityService.getActivityById(id);
            return View(activity);
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Description,Photo")] Activity activity, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    activity.Photo = file.FileName;
                    if (file.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                        file.SaveAs(path);
                    }
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
        // GET: Activity/Delete/5
        public ActionResult deleteAllActivity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult deleteAllActivity([Bind(Include = "Description,Photo")] Activity activity)
        {
            KinderGarten k = kinderGartenService.findUserByIdK((int)Session["id"]);

            if (activityService.deleteAllActivity(k.Id,activity))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}


