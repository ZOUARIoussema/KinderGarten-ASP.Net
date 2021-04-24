using Model;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class KinderGartenController : Controller
    {
        KinderGartenService kinderGartenService;
        // GET: KinderGarten


        public KinderGartenController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            User usergarten = (User)System.Web.HttpContext.Current.Session["User"];

            kinderGartenService = new KinderGartenService(token);
        }
        public ActionResult Index()
        {
            return View(kinderGartenService.GetAllKinder());
        }

        // GET: KinderGarten/Details/5
        public ActionResult Details(int id)
        {
            KinderGarten kinderGarten = kinderGartenService.getKindergartenById(id);
            if (kinderGarten != null)
            {
                return View(kinderGarten);
            }
            return View();
        }

        // GET: KinderGarten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KinderGarten/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Email,Adress,Tel,Logo,Latitude,Longitude")] KinderGarten kinder, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                kinder.Logo = file.FileName;
              
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }
                if (kinderGartenService.AddKinder(kinder))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: KinderGarten/Edit/5
        public ActionResult Edit(int id)
        {
            KinderGarten kinderGarten = kinderGartenService.getKindergartenById(id);

            return View(kinderGarten);
        }

        // POST: KinderGarten/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Name,Email,Adress,Tel,Logo,Latitude,Longitude")] KinderGarten kinderGarten, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    kinderGarten.Logo = file.FileName;
                    if (file.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                        file.SaveAs(path);
                    }
                    if (kinderGartenService.UpdateKinder(id, kinderGarten))
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

        // GET: KinderGarten/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KinderGarten/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (kinderGartenService.deleteKindergartenById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
