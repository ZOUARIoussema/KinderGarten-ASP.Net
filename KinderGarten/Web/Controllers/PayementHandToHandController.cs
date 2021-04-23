using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Model;

namespace Web.Controllers
{
    public class PayementHandToHandController : Controller
    {

        PayementService payementService;

        public PayementHandToHandController()
        {
           String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            payementService = new PayementService(token);
        }

       private  static int idSubscription;

        // GET: PayementHandToHand
        public ActionResult Index()
        {
            return View(payementService.GetAllPayement());
        }

        // GET: PayementHandToHand/Details/5
        public ActionResult Details(int id)
        {


            ViewBag.Lien = "http://localhost:8081/accounting/detailSubscription/1";


            return View(payementService.GetAllPayementBySubscription(id));
        }


        public ActionResult DetailsPayement(int id)
        {


            return View();
        }
        


        // GET: PayementHandToHand/Create
        public ActionResult GetListSubscription()
        {
            return View(payementService.GetAllSubscription().Where(s=>s.RestPay!=0));
        }

        // GET: PayementHandToHand/Create
        public ActionResult Create(int id)
        {
            idSubscription = id;
            return View();
        }

        // POST: PayementHandToHand/Create
        [HttpPost]
        public ActionResult Create([ Bind(Include =("Price,TypePayement,CheckNumber,DateCheck"))]PayementSubscription payementSubscription)
        {
            
                if (payementService.AddPayementHandToHand(payementSubscription, "oussema.zouari@esprit.tn",idSubscription))
                {
                    return RedirectToAction("Index");
                }

                
            
                return View();
             
        }

        // GET: PayementHandToHand/Edit/5
        public ActionResult Edit(int id)
        {
            return View(payementService.FindById(id));
        }

        // POST: PayementHandToHand/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = ("Price,TypePayement,CheckNumber,DateCheck"))] PayementSubscription payementSubscription)
        {
             
                if (payementService.UpdatePayementSubscription(payementSubscription))
                {
                    return RedirectToAction("Index");
                }

                
             
                return View();
            
        }

        // GET: PayementHandToHand/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PayementHandToHand/Delete/5
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
