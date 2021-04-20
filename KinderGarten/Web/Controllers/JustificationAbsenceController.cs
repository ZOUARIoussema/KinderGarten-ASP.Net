using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class JustificationAbsenceController : Controller
    {
        JustificationAbsenceService justificationAbsenceService = new JustificationAbsenceService();
        // GET: JustificationAbsence
        public ActionResult Index()
        {
            return View();
        }

        // GET: JustificationAbsence/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JustificationAbsence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JustificationAbsence/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Description")]JustificationAbsence justificationAbsence)
        {
            if (justificationAbsenceService.Add(justificationAbsence))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: JustificationAbsence/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JustificationAbsence/Edit/5
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

        // GET: JustificationAbsence/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JustificationAbsence/Delete/5
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
