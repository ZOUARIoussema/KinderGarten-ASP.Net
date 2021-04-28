using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class EstimateController : Controller
    {
        EstimateService estimateService ;
        public EstimateController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            User usergarten = (User)System.Web.HttpContext.Current.Session["User"];

            estimateService = new EstimateService(token);
        }
        // GET: Estimate
        public ActionResult Index()
        {
            return View(estimateService.GetAll());
        }
        public ActionResult EstimateFilter()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/user/findUser/" + Session["id"]).Result;
            User user = new User();
            if (response.IsSuccessStatusCode)
            {
                user = response.Content.ReadAsAsync<User>().Result;
            }

            return View(estimateService.EstimateFilter(user.Id));
        }

        // GET: Estimate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estimate/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Item,Qte,DateC,Total")] Estimate estimate)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8081");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("/user/findUser/" + Session["id"]).Result;
                User user = new User();
                if (response.IsSuccessStatusCode)
                {
                    user = response.Content.ReadAsAsync<User>().Result;
                }
                
                if (estimateService.Add(estimate,user.Id))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: Estimate/Edit/5
        public ActionResult Edit(DateTime dateC, int iduser, int idkinder)
        {
            return View();
        }

        // POST: Estimate/Edit/5
        [HttpPost]
        public ActionResult Edit(DateTime dateC, int iduser, int idkinder, [Bind(Include = "Item,Qte,Total")] Estimate estimate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (estimateService.Update(dateC, iduser, idkinder, estimate))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        // POST: Estimate/Delete/5
      
        public ActionResult Delete(DateTime dateC)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/user/findUser/" + Session["id"]).Result;
            User user = new User();
            if (response.IsSuccessStatusCode)
            {
                user = response.Content.ReadAsAsync<User>().Result;
            }

            if (estimateService.deleteEstimate(dateC, user.Id, 3))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
