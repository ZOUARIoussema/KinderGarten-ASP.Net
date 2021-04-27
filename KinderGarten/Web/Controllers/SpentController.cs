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
    public class SpentController : Controller
    {



        SpentService spentService;
        

        public SpentController()
        {

            

            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            spentService = new SpentService(token);

        }


        // GET: Spent
        public ActionResult Index()
        {

           

            User u = (User)System.Web.HttpContext.Current.Session["User"];

            if (u != null)
            {

                String dateS = DateTime.Now.ToString("d");
                String date = dateS.Replace("/", "-");

                ViewBag.LienXL = "http://localhost:8081/accounting/export/excel/" + date;

                System.Diagnostics.Debug.WriteLine(date);

                return View(spentService.getAll(u.Id));
            }

            return View(new List<Spent>());
        }

        // GET: Spent/Details/5
        public ActionResult Details(int id)
        {

            Spent spent = spentService.FindById(id);

                if (spent != null)
                {

                    return View(spent);
                }
         

            return View();
        }

        // GET: Spent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spent/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description,Total,TypeSepent")] Spent spent)
        {

            User u = (User)System.Web.HttpContext.Current.Session["User"];

            if (u != null)
            {
                spent.AgentCashier = u;

                if (ModelState.IsValid && spentService.AddSpent(spent))
                {

                    return RedirectToAction("Index");
                }

            }
             
                return View();
             
        }

        // GET: Spent/Edit/5
        public ActionResult Edit(int id)
        {

            Spent spent = spentService.FindById(id);

            if (spent != null)
            {

                return View(spent);
            }

            return View();
        }

        // POST: Spent/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Description,Total,TypeSepent,DateC")] Spent spent)
        {
            User u = (User)System.Web.HttpContext.Current.Session["User"];

            if (u != null)
            {

                spent.AgentCashier = u;

                if (ModelState.IsValid && spentService.UpdateSpent(spent))
                {

                    return RedirectToAction("Index");
                }

            }
            
                return View();
             
        }

        // GET: Spent/Delete/5
        public ActionResult Delete(int id)
        {

            Spent spent = spentService.FindById(id);

            if (spent != null)
            {

                return View(spent);
            }
            return View();
        }

        // POST: Spent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {


            if (spentService.DeleteSpent(id))
            {

                return RedirectToAction("Index");
            }
            
                return View();
             
        }
    }
}
