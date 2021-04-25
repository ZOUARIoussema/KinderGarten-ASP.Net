using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class SubscriptionChildController : Controller
    {
        SubscriptionChildService subscriptionChildService = new SubscriptionChildService();
        public SubscriptionChildController() { 
        }
        // GET: SubscriptionChild
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubscriptionChild/Details/5
        public ActionResult Details(int id)
        {
            SubscriptionChild subscriptionChild = subscriptionChildService.GetById(id);
            if (subscriptionChild != null)
            {
                return View(subscriptionChild);
            }
            return View();
        }

        // GET: SubscriptionChild/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(subscriptionChildService.GetAllCategorySubscription(), "Id","Description");
            
            ViewBag.LisExtras = new SelectList(subscriptionChildService.GetAllExtra(), "Id", "Description","Price");
            return View();
        }

        // POST: SubscriptionChild/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "DateC,DateStart,DateEnd,categorySubscription,lisExtras,CategoryId")]SubscriptionChild subscriptionChild)
        {



            if (subscriptionChildService.Add(subscriptionChild))
            {
                return RedirectToAction("Index");
            }
            return View();
        }





        // GET: SubscriptionChild/Edit/5
        public ActionResult Edit(int id)
        {
            SubscriptionChild subscriptionChild = subscriptionChildService.GetById(id);

            if (subscriptionChild != null)
            {

                return View(subscriptionChild);
            }

            return View();
        }

        // POST: SubscriptionChild/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id,DateC,DateStart,DateEnd,categorySubscription,lisExtras")] SubscriptionChild subscriptionChild)
        {
            if (subscriptionChildService.UpdateSubscriptionChild(subscriptionChild))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: SubscriptionChild/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubscriptionChild/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (subscriptionChildService.DeleteSubscriptionChild(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        
    
    }
}
