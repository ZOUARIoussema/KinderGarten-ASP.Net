using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Index()
        {
           ViewBag.LienXL = "http://localhost:8081/accounting/export/excel/"+DateTime.Now.ToString("d");
            return View();
        }
    }
}