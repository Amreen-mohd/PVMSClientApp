using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PVMSClientApp.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PVMSClientApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegistration()
        {
            List<string> qlist = new List<string>();
            string q = "what is your pet name";
            string q1 = "what is your favourite holiday spot";
            string q3 = "who is your favourite actor";
            string q4 = "what is your nationality";
            qlist.Add(q1);
            qlist.Add(q3);
            qlist.Add(q4);
            qlist.Add(q);
            ViewBag.qlist = qlist;
            return View();
        }
        [HttpPost]
        public ActionResult UserRegistration(user_registration2 user)
        {
            List<string> qlist = new List<string>();
            string q = "what is your pet name";
            string q1 = "what is your favourite holiday spot";
            string q3 = "who is your favourite actor";
            string q4 = "what is your nationality";
            qlist.Add(q1);
            qlist.Add(q3);
            qlist.Add(q4);
            qlist.Add(q);
            ViewBag.qlist = qlist;
            if (ModelState.IsValid)
            {
                user_registration2 res = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44386/api/");
                    var responseTask = client.PostAsJsonAsync<user_registration2>("User/AddUser", user);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    var readData = result.Content.ReadAsAsync<user_registration2>();
                    if (result.IsSuccessStatusCode)
                    {
                        res = readData.Result;
                        ModelState.Clear();
                        TempData["flag"] = "true";

                        TempData["UserID"] = res.userId;
                        TempData["Password"] = res.password;

                        return RedirectToAction("UserLogin", new { success = true });
                    }
                    else
                    {
                        //res = readData.Result;
                        ViewBag.msg = "Failed To Register";
                        return View();
                    }
                }
            }

            return View();
        }

        public ActionResult userLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult userLogin(userLogin user)
        {
            //Validate Google recaptcha here
            var response = Request["g-recaptcha-response"];
            string secretKey = "6Lc3E6onAAAAALlGobkwuUq2yMiWZp0vq_6PHi3z";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
            if (ModelState.IsValid)
            {
                string res = "";
                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri("https://localhost:44386/api/");
                    var responseTask = client2.PostAsJsonAsync<userLogin>("User/LoginUser", user);
                    responseTask.Wait();
                    var result2 = responseTask.Result;
                    var readData = result2.Content.ReadAsAsync<string>();
                    if (result2.IsSuccessStatusCode)
                    {
                        Session["userId"] = user.userId;
                        res = readData.Result;
                        ViewBag.msg = res;
                        ModelState.Clear();
                        return RedirectToAction("Index", "Services");
                    }
                    else
                    {
                        res = readData.Result;
                        ViewBag.msg = "Invalid Credentials";
                        return View();
                    }
                }
            }

            ViewBag.msg = "* Invalid Credentials";
            return View();
        }

        public ActionResult ForgotPassword()
            {
                return View();
            }

            [HttpPost]
            public ActionResult ForgotPassword(string email)
            {
            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTask = client2.GetAsync("Email/SendEmail?email=" + email);
                responseTask.Wait();
                var result2 = responseTask.Result;
                var readData = result2.Content.ReadAsAsync<string>();
                if (result2.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Check your email";
                    return View();
                }
                else
                {
                    ViewBag.msg = "No address found";
                    return View();
                }
            }
           
            }
        public ActionResult verifyphone(string phno)
        {
            
            string P = null;
            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri("https://localhost:44386/");
                var responseTask = client2.GetAsync("api/User/GetContact?res=" + phno);
                responseTask.Wait();
                var result2 = responseTask.Result;
                var readData = result2.Content.ReadAsAsync<string>();
                if (result2.IsSuccessStatusCode)
                {
                    P = readData.Result;
                    if (P == "exists")
                    {
                        string VP = "Phone No already exists";
                        return Json(VP);
                    }
                    else
                    {
                        string VP = "";
                        return Json(VP);
                    }
                }
                return View();
            }
           




        }
        public ActionResult verifyemail(string email)
        {

            string P = null;
            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri("https://localhost:44386/");
                var responseTask = client2.GetAsync("api/User/GetEmail?res=" + email);
                responseTask.Wait();
                var result2 = responseTask.Result;
                var readData = result2.Content.ReadAsAsync<string>();
                if (result2.IsSuccessStatusCode)
                {
                    P = readData.Result;
                    if (P == "exists")
                    {
                        string VP = "Email already exists";
                        return Json(VP);
                    }
                    else
                    {
                        string VP = "";
                        return Json(VP);
                    }
                }
                return View();
            }





        }

    }
}