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


            ViewBag.Lien = "http://localhost:8081/accounting/detailSubscription/"+id;


            return View(payementService.GetAllPayementBySubscription(id));
        }


        public ActionResult DetailsPayement(int id)
        {


            return View();
        }
        


        // GET: PayementHandToHand/Create
        public ActionResult GetListSubscription(String filtre)
        {

            if (String.IsNullOrEmpty(filtre))
            {

                return View(payementService.GetAllSubscription().Where(s => s.RestPay != 0));
            }

            return View(payementService.GetAllSubscription().Where( s=> (s.RestPay!=0 && s.Child.Name.ToLower()
            .Contains(filtre.ToLower()) )  ));
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
            User u = (User)System.Web.HttpContext.Current.Session["User"];

            if (u != null)
            {

                payementSubscription.User = u;

                if (ModelState.IsValid && payementService.AddPayementHandToHand(payementSubscription, "oussema.zouari@esprit.tn", idSubscription))
                {
                    return RedirectToAction("Index");
                }

            }  
            
                return View();
             
        }

        // GET: PayementHandToHand/Edit/5
        public ActionResult Edit(int id)
        {

            PayementSubscription payementSubscription = payementService.FindById(id);



            if (payementSubscription != null)
            {
                idSubscription = payementSubscription.SubscriptionChild.Id;
                return View(payementSubscription);
            }

            return View();
        }

        // POST: PayementHandToHand/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = ("Price,TypePayement,CheckNumber,DateCheck,Id"))] PayementSubscription payementSubscription)
        {

            User u = (User)System.Web.HttpContext.Current.Session["User"];

            if (u != null)
            {

                payementSubscription.User = u;
                payementSubscription.SubscriptionChild.Id = idSubscription;

                if (ModelState.IsValid && payementService.UpdatePayementSubscription(payementSubscription))
                {
                    return RedirectToAction("Index");
                }

            }   
             
                return View();
            
        }

        // GET: PayementHandToHand/Delete/5
        public ActionResult Delete(int id)
        {

            PayementSubscription payement = payementService.FindById(id);

            if (payement != null)
            {
                return View(payement);
            }

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
