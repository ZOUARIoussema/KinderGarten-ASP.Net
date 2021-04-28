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
        public static int idS;
        public static double totalS;

        public PayementEnLigneSubscriptionChildController()
        {

            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            payementService = new PayementService(token);

        }

        // GET: PayementEnLigneSubscriptionChild
        public ActionResult Index(int id,double total)
        {
            idS = id;
            totalS = total;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {

            SubscriptionChild s = new SubscriptionChild();
            s.Id = idS;

            PayementSubscription payementSubscription = new PayementSubscription();
            payementSubscription.TypePayement = TypePayement.onLine;
            payementSubscription.Price = totalS;
            payementSubscription.SubscriptionChild = s;

            User u = (User)System.Web.HttpContext.Current.Session["User"];

            if (u != null)
            {
                payementSubscription.User = u;
            }

            if (payementService.AddPayementOnLigne(payementSubscription, "oussema.zouari@esprit.tn"))
            {

                return RedirectToAction("ListSubscriptionChild");
            }

            return View();
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
