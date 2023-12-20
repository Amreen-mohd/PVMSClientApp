using CaptchaMvc.HtmlHelpers;
using PVMSClientApp.Models.BL;
using PVMSClientApp.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PVMSApp.Controllers
{
    public class PassportRegController : Controller
    {
        // GET: PassportReg
                DbValidation V = new DbValidation();

        public ActionResult PassportRegistration()
        {
            ViewBag.slist = V.validateState();
            //string userId = Request.Cookies["userId"].Value;
            string userId = Session["userId"].ToString();
            //string userId = "USERXXXX";
            passport p = new passport();
            p.userId=userId;

            return View(p);

        }
        public JsonResult getcities(string sId)
        {
            List<city> cities = V.validateCity(sId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult PassportRegistration(passport p)
        {
            List<city> cities = V.validateCity(p.state);
            ViewBag.slist = V.validateState();
            if (!this.IsCaptchaValid(""))
            {
                ViewBag.ErrorMessage = "Captcha is not valid";
                return View("PassportRegistration", p);
            }
            string userId = Session["userId"].ToString();
            
            p.userId = userId;
            p.country = "India";
            
            if (ModelState.IsValid)
            {
                string res = "";
                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri("https://localhost:44386/api/");
                    var responseTask = client2.PostAsJsonAsync<passport>("PassportReg/Passport", p);
                    responseTask.Wait();
                    var result2 = responseTask.Result;
                    var readData = result2.Content.ReadAsAsync<string>();
                    if (result2.IsSuccessStatusCode)
                    {
                        res = readData.Result;
                        ViewBag.msg = res;
                        ModelState.Clear();
                        return RedirectToAction("Success", "PassportReg",p);
                    }
                    else
                    {
                        res = readData.Result;
                        ViewBag.msg = res;
                        return View(p);
                    }
                }
            }
            return View(p);
        }
        public ActionResult Success(passport passport)
        {
            passport p = null;
            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTask = client2.PostAsJsonAsync<passport>("PassportReg/Success", passport);
                responseTask.Wait();
                var result2 = responseTask.Result;
                var readData = result2.Content.ReadAsAsync<passport>();
                if (result2.IsSuccessStatusCode)
                {
                    p = readData.Result;
                    //Session["passportId"] = p.passportId;
                    return View(p);
                    
                }
            }
            return View(p);
        }
    }
}