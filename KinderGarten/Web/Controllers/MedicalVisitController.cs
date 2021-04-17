using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace Web.Controllers
{
    public class MedicalVisitController : Controller
    {

        MedicalVisitService medicalVisitService = new MedicalVisitService();

        // GET: MedicalVisit
        public ActionResult Index()
        {
            return View();
        }

       
        public JsonResult GetEvents()
        {


            System.Diagnostics.Debug.WriteLine("****"+medicalVisitService.GetAll().Count());
           return new JsonResult { Data = medicalVisitService.GetAll().ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
             


            

        }

      
    }
}