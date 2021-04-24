using Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Service;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ClaimsService claimservice = new ClaimsService();
        private UserService userservice;

        public AdminController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            userservice = new UserService(token);
        }




        // GET: Admin
        public ActionResult Index()
        {
            return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "Id,FirstName,LastName,Email,Password,ConfirmPassword,Address,Tel")] User usertomodify)
        {
            if (ModelState.IsValid)
            {
                HttpClient httpclientprofile = new HttpClient();
                httpclientprofile.BaseAddress = new Uri("http://localhost:8081/");

                httpclientprofile.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var APIResponse = httpclientprofile.PutAsJsonAsync<User>(Statics.baseAddress + "user/update",
                 usertomodify).Result;


                System.Diagnostics.Debug.WriteLine("email user to modify " + usertomodify.Email);

                if (APIResponse.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine(usertomodify.ToString());

                    ViewBag.Message = "Account updated  successfully !";

                    return View();
                }
            }

            return View();
        }


        public ActionResult EditProfile(int id)
        {
            System.Diagnostics.Debug.WriteLine("******iduserprofile" + id);

            User userp = userservice.findUserById(id);

            System.Diagnostics.Debug.WriteLine(userp.ToString());

            if (userp != null)
            {

                return View(userp);
            }


            return View();
        }


   

        public ActionResult Claims()
        {
            
           
            HttpClient httpclientclaims = new HttpClient();
            httpclientclaims.BaseAddress = new Uri(Statics.baseAddress);
            httpclientclaims.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpclientclaims.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}"," "+Session["AccessToken"]));



            var response = httpclientclaims.GetAsync(Statics.baseAddress + "admin/getAllClaims").Result;

            System.Diagnostics.Debug.WriteLine(response.StatusCode);

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

        

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
