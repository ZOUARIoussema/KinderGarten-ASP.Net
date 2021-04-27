using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AccountingController : Controller
    {




        PayementService payementService;


        public AccountingController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            payementService = new PayementService(token);
        }


        // GET: Accounting
        public ActionResult Index(String filtre)
        {

            if (String.IsNullOrEmpty(filtre))
            {

                return View(payementService.GetAllSubscription().Where(s => s.RestPay != 0));
            }

            return View(payementService.GetAllSubscription().Where(s => (s.RestPay != 0 && s.Child.Name.ToLower()
           .Contains(filtre.ToLower()))));
        }


        public ActionResult Transfert()
        {
            return View();
        }
    }
}