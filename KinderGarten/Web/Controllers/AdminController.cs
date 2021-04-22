using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Service;
using System.Web.Security;

namespace Web.Controllers
{

    public class AdminController : Controller
    {
        private ClaimsService claimservice = new ClaimsService();
        private UserService userservice = new UserService();




        // GET: Admin
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
           
        }




        public ActionResult Claims()
        {
            FormsIdentity id = (FormsIdentity)User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            System.Diagnostics.Debug.WriteLine("token :" + ticket.ToString());

            string token = Session["token"].ToString();

            HttpClient httpclientclaims = new HttpClient();
            httpclientclaims.BaseAddress = new Uri(Statics.baseAddress);
            httpclientclaims.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpclientclaims.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", ticket.UserData));

            var response = httpclientclaims.GetAsync(Statics.baseAddress + "admin/getAllClaims").Result;

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Claim> claims = response.Content.ReadAsAsync<IEnumerable<Claim>>().Result;

                return View(claims);

            }

            return View(new List<Claim>());
        }

        public ActionResult Users()
        {

            return View(userservice.GetAll());
        }


        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(userservice.GetById(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            if (userservice.DeleteUser(id))
            {
                return RedirectToAction("Users");
            }

            return View();
        }
    }
}
