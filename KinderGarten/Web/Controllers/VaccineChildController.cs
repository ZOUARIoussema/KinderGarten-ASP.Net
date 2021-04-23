using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    public class VaccineChildController : Controller
    {


        VaccineChildService vaccineChildService;

        public VaccineChildController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            vaccineChildService = new VaccineChildService(token);
             
        }

        // GET: VaccineChild
        public ActionResult Index()
        {


            
            return View(vaccineChildService.GetAll());
        }

        // GET: VaccineChild/Details/5
        public ActionResult Details(int id)
        {


            ChildVaccine vaccine = vaccineChildService.GetById(id);

            if (vaccine != null)
                {

                    return View(vaccine);
                }
 

            return View();
        }

        // GET: VaccineChild/Create
        public ActionResult Create()
        {



            return View();
        }

        // POST: VaccineChild/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "MonthNumber,Description")] ChildVaccine childVaccine)
        {




            if (vaccineChildService.AddVaccine(childVaccine))
            {

                return RedirectToAction("Index");
            }
             
                return View();
             
        }

        // GET: VaccineChild/Edit/5
        public ActionResult Edit(int id)
        {


            ChildVaccine vaccine = vaccineChildService.GetById(id);
            

                if (vaccine != null)
                {

                    return View(vaccine);
                }
             

            return View();
        }

        // POST: VaccineChild/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,MonthNumber,Description")] ChildVaccine childVaccine)
        {


            if (vaccineChildService.UpdateVaccine(childVaccine))
            {
                return RedirectToAction("Index");
            }
             
                return View();
             
        }

        // GET: VaccineChild/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VaccineChild/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {


            if (vaccineChildService.Delete(id))
            {

                return RedirectToAction("Index");

            }
            
                return View();
             
        }
    }
}
