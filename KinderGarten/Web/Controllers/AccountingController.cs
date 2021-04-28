using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Web.Controllers
{
    public class AccountingController : Controller
    {




        PayementService payementService;
        private static int idS;


        public AccountingController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            payementService = new PayementService(token);
        }


        // GET: Accounting
        public ActionResult Index(String filtre)
        {


            IEnumerable<SubscriptionChild> list = payementService.GetAllSubscription().Where(s => s.RestPay != 0);

            double total = list.Select(s => s.Total).Sum();
            double totalR = list.Select(s => s.RestPay).Sum();

            ViewBag.Total = total;
            ViewBag.TotalR = totalR;


            if (String.IsNullOrEmpty(filtre))
            {

                return View(list);
            }

            return View(list.Where(s => s.Child.Name.ToLower()
           .Contains(filtre.ToLower())));
        }


        public ActionResult Transfert(int id)
        {



            idS = id;

            return View();
        }
        [HttpPost]
        public ActionResult Transfert([Bind(Include = "PointFidelity")] TransfertModelView transfertModelView)
        {

            transfertModelView.SubscriptionChildId = idS;

            if (payementService.TransfertPoint(transfertModelView))
            {

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}