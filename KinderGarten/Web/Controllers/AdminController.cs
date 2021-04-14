using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;


namespace Web.Controllers
{
  
    public class AdminController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

       

        public AdminController()
        { 

            baseAddress = "http://localhost:8081";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Claims()
        {
            httpClient.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJhZG1pbkBnbWFpbC5jb20iLCJhdXRoIjoiUk9MRV9hZG1pbiIsImlhdCI6MTYxODM4ODE1MiwiZXhwIjoxNjE5MjUyMTUyfQ.Xuru9tmpO_iabBcd44Tt--njjchL3TRZv2D22iJM2pU");
           
            HttpResponseMessage response = httpClient.GetAsync("admin/getAllClaims").Result;
            IEnumerable<Claim> claims;
            if (response.IsSuccessStatusCode)
            {

                claims = response.Content.ReadAsAsync<IEnumerable<Claim>>().Result;
            }
            else
            {
                claims = null;
            }
            return View(claims);
        }

        public ActionResult Users()
        {
            httpClient.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJhZG1pbkBnbWFpbC5jb20iLCJhdXRoIjoiUk9MRV9hZG1pbiIsImlhdCI6MTYxODM4ODE1MiwiZXhwIjoxNjE5MjUyMTUyfQ.Xuru9tmpO_iabBcd44Tt--njjchL3TRZv2D22iJM2pU");
            HttpResponseMessage response = httpClient.GetAsync("/useradmin/findAll").Result;

            IEnumerable<User> users;
            if (response.IsSuccessStatusCode)
            {

                users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                users = null;
            }
            return View(users);
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
            httpClient.DefaultRequestHeaders.Authorization =
             new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJhZG1pbkBnbWFpbC5jb20iLCJhdXRoIjoiUk9MRV9hZG1pbiIsImlhdCI6MTYxODM4ODE1MiwiZXhwIjoxNjE5MjUyMTUyfQ.Xuru9tmpO_iabBcd44Tt--njjchL3TRZv2D22iJM2pU");

            HttpResponseMessage response = httpClient.GetAsync("/useradmin/findAll").Result;

            IEnumerable<User> users;
            if (response.IsSuccessStatusCode)
            {

                users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                users = null;
            }
            return View(users);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               
                    var APIResponse = httpClient.DeleteAsync(baseAddress + "useradmin/delete/"+id);

                    return RedirectToAction("Users");


            }
            catch
            {
                return View();
            }
        }
    }
}
