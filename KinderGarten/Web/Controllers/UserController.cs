using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Web.Security;

namespace Web.Controllers
{
    public class UserController : Controller
    {





        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]

        public ActionResult Register([Bind(Include = "Role,FirstName,LastName,Email,Password,ConfirmPassword,Address,Tel")] User user)
        {

            if (ModelState.IsValid)
            {
                HttpClient httpclient = new HttpClient();
                httpclient.BaseAddress = new Uri("http://localhost:8081/");
                httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseadduser = httpclient.PostAsJsonAsync(Statics.baseAddress + "user/add", user).Result;

                if (responseadduser.IsSuccessStatusCode)
                {
                    ViewBag.Message = "registration successfully completed !";

                    return View();

                }
            }
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }


        public ActionResult SuccessPage()
        {
            return View();
        }


        public ActionResult VerifyCodeAndChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyCodeAndChangePassword([Bind(Include = "Code,Password,confirmpassword,email")] CodeVerifPass cvp)
        {
            if (ModelState.IsValid)
            {
                string email = cvp.email;


                System.Diagnostics.Debug.WriteLine("email  " + email);

                var httpc = new HttpClient();

                httpc.BaseAddress = new Uri("http://localhost:8081/user");

                httpc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseuseremail = httpc.GetAsync(Statics.baseAddress + "user/findUserByEmail/" + email).Result;

                var useremail = responseuseremail.Content.ReadAsStringAsync().Result;

                User u = JsonConvert.DeserializeObject<User>(useremail);



                System.Diagnostics.Debug.WriteLine("user : " + u.Id);

                int id = u.Id;

                var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:8081/user/");

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.PutAsJsonAsync<CodeVerifPass>("changepwd/" + id + "/" + cvp.Password + "/" + cvp.Code, cvp).Result;


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("SuccessPage", "User");
                }
            }


            return View();

        }


        public ActionResult ForgetPassword()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ForgetPassword(FormCollection form)
        {
            string email = form["dzName"];

            Session["Email"] = email;

            System.Diagnostics.Debug.WriteLine("********email : ************:" + email);

            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:8081/");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = httpClient.PostAsync(Statics.baseAddress + "user/sendSecretKey/" + email, null).Result;

            var result = response.Content.ReadAsStringAsync().Result.ToString();

            System.Diagnostics.Debug.WriteLine("response" + result);

            if (response.IsSuccessStatusCode)
            {

                // return RedirectToAction("ChangePassword", "User");
                return RedirectToAction("VerifyCodeAndChangePassword", "User");
            }
            return View();
        }



        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] User userlogin)
        {
            System.Diagnostics.Debug.WriteLine("email :" + userlogin.Email + ",password :" + userlogin.Password);

            HttpClient httpuserauth = new HttpClient();
            httpuserauth.BaseAddress = new Uri("http://localhost:8081/");
            httpuserauth.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var responseloginuser = httpuserauth.PostAsJsonAsync(Statics.baseAddress + "user/authenticate", userlogin).Result;

            if (responseloginuser.IsSuccessStatusCode)
            {
                var userauth = responseloginuser.Content.ReadAsStringAsync().Result;

                var s = JsonConvert.DeserializeObject<userauthenticated>(userauth);

                FormsAuthentication.SetAuthCookie(s.username, false);

                Session["token"] = s.token;

                 System.Diagnostics.Debug.WriteLine("user authenticated  :" + s);

                System.Diagnostics.Debug.WriteLine("user authenticated  :" + s.token);


                foreach (string role in s.authorities)
                {
                    System.Diagnostics.Debug.WriteLine(role);

                    var rolesplitted  =  role.Split('_');

                    Session["role"] = rolesplitted;

                    if (role.Equals("ROLE_admin"))

                        return RedirectToAction("Index", "Admin");

                    if (role.Equals("ROLE_visitor"))

                        return RedirectToAction("Index", "Home");
                }
                System.Diagnostics.Debug.WriteLine(s.authorities.ToString());

              //  return RedirectToAction("Index", "Home");


            }
            return View();
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
