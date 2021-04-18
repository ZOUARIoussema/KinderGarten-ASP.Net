using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Web.Controllers
{
    public class UserController : Controller
    {

        private UserService userservice = new UserService();

        public ActionResult Login()
        {


            return View();
        } 
        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Password")] User user)
        {

            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:8081/user/");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = httpClient.PostAsJsonAsync<User>("authenticate", user);


            response.Wait();
            var result = response.Result;
               
            if (ModelState.IsValid)
            {
                if (result.IsSuccessStatusCode)
                {
                    String userauthenticated = result.Content.ToString();

                    Console.WriteLine(userauthenticated);

                    System.Diagnostics.Debug.WriteLine(userauthenticated);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "error in login , try again");
            return View(user);
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
