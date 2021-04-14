using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class KinderGartenController : Controller
    {
        KinderGartenService kinderGartenService = new KinderGartenService();
        // GET: KinderGarten
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
        public ActionResult Create([Bind(Include = "Name,Email,Adress,Tel,Logo,Latitude,Longitude")] KinderGarten kinder)
        {
            if (kinderGartenService.AddKinder(kinder))
            {
                return RedirectToAction("Index");
            }
            return View();
            
        }

        // GET: KinderGarten/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KinderGarten/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Name,Email,Adress,Tel,Logo,Latitude,Longitude")] KinderGarten kinderGarten)
        {
            try
            {
                if (kinderGartenService.UpdateKinder(id,kinderGarten))
                {
                    return RedirectToAction("Index");
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
