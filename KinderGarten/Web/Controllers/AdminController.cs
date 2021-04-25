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
        private ClaimsService claimservice;
        private UserService userservice = new UserService();

        public AdminController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            // userservice = new UserService(token);

            claimservice = new ClaimsService(token);
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


   
        [Authorize]
        public ActionResult Claims(String searchbyparent )
        {



            if (String.IsNullOrEmpty(searchbyparent))
            {

                return View(claimservice.GetAll());
            }
         else
            {
           
                return View(claimservice.getClaimsByParent(searchbyparent));
            }
             
        }

        public ActionResult Users()
        {

            return View(userservice.GetAll());
        }

      

        [HttpPost]
        public ActionResult ChangeState(int idclaim)
        {
            String response = claimservice.ChangeStateClaim(idclaim);

           // ViewBag.message = response;

            return RedirectToAction("Claims", "Admin");
        }


        // GET: Admin/Details/5
        public ActionResult DetailsClaim(int id)
        {
            return View(claimservice.getClaimById(id));
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
