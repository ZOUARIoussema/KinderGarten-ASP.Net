using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Model;
namespace Web.Controllers

{
    public class PayementEnLigneSubscriptionChildController : Controller
    {

        PayementService payementService;

        public PayementEnLigneSubscriptionChildController()
        {

            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            payementService = new PayementService(token);

        }

        // GET: PayementEnLigneSubscriptionChild
        public ActionResult Index(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index()
        {
           
            return RedirectToAction("ListSubscriptionChild");
        }




        // GET: PayementEnLigneSubscriptionChild
        public ActionResult ListSubscriptionChild()
        {
            User u = (User)System.Web.HttpContext.Current.Session["User"];


            if (u != null)
            {
                return View(payementService.GetAllSubscriptionByParent(u.Id));
            }

                return View(new List<SubscriptionChild>());
        }








    }
    }
