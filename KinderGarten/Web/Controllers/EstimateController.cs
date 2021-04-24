using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class EstimateController : Controller
    {
        EstimateService estimateService ;
        public EstimateController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            User usergarten = (User)System.Web.HttpContext.Current.Session["User"];

            estimateService = new EstimateService(token);
        }
        // GET: Estimate
        public ActionResult Index()
        {
            return View(estimateService.GetAll());
        }
        public ActionResult EstimateFilter()
        {
            return View(estimateService.EstimateFilter());
        }

        // GET: Estimate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estimate/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Item,Qte,DateC,Total")] Estimate estimate)
        {
            if (ModelState.IsValid)
            {
                if (estimateService.Add(estimate))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: Estimate/Edit/5
        public ActionResult Edit(DateTime dateC, int iduser, int idkinder)
        {
            return View();
        }

        // POST: Estimate/Edit/5
        [HttpPost]
        public ActionResult Edit(DateTime dateC, int iduser, int idkinder, [Bind(Include = "Item,Qte,Total")] Estimate estimate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (estimateService.Update(dateC, iduser, idkinder, estimate))
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

        // GET: Estimate/Delete/5
        public ActionResult Delete(DateTime dateC, int iduser, int idkinder)
        {
            return View();
        }

        // POST: Estimate/Delete/5
        [HttpPost]
        public ActionResult Delete(DateTime dateC, int iduser, int idkinder, FormCollection collection)
        {
            if (estimateService.deleteEstimate(dateC, iduser, idkinder))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
