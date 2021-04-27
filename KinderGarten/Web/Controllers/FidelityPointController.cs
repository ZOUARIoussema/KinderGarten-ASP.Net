using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FidelityPointController : Controller
    {
        // GET: FidelityPoint
        public ActionResult Index()
        {
            return View();
        }

        // GET: FidelityPoint/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FidelityPoint/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FidelityPoint/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FidelityPoint/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FidelityPoint/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FidelityPoint/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FidelityPoint/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
