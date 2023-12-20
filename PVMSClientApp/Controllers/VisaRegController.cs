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

namespace PVMSClientApp.Controllers
{
    public class VisaRegController : Controller
    {
        // GET: VisaReg
        DbValidation V = new DbValidation();
        public ActionResult VisaRegistration()
        {
            ViewBag.cmsg = "Yes";
            ViewBag.vlist = V.getvisaType1();
            ViewBag.userId = Session["userId"].ToString();
            ViewBag.passportId = Session["passportId"].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult VisaRegistration(visa v)
        {
            string res = "";
            ViewBag.vlist = V.getvisaType1();
            ViewBag.userId = Session["userId"].ToString();
            ViewBag.passportId = Session["passportId"].ToString();
            if (!this.IsCaptchaValid(""))
            {
                ViewBag.ErrorMessage = "Captcha is not valid";
                return View("VisaRegistration", v);
            }
            v.dateOfApplication = DateTime.Now;
            v.userId = Session["userId"].ToString();
            v.passportId = Session["passportId"].ToString().Split(' ')[0];
            ViewBag.cmsg = "Yes";
            if (ModelState.IsValid)
            {
                if (V.GetVisaCountryValidation(v).Equals("success"))
                {
                    using (var client2 = new HttpClient())
                    {
                        client2.BaseAddress = new Uri("https://localhost:44386/api/");
                        var responseTask = client2.PostAsJsonAsync<visa>("VisaReg/Visa", v);
                        responseTask.Wait();
                        var result2 = responseTask.Result;
                        var readData = result2.Content.ReadAsAsync<string>();
                        if (result2.IsSuccessStatusCode)
                        {
                            res = readData.Result;
                            return RedirectToAction("Success", "VisaReg", new { res = res });
                        }
                        else
                        {
                            res = readData.Result;
                            ViewBag.msg = res;
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.cmsg = "You Already Have an Active Visa for" + v.country;
                    return View();
                }
            }

            return View();
        }
        public ActionResult Success(string res)
        {
            

            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTask = client2.GetAsync("VisaReg/Success?res="+ res);
                responseTask.Wait();
                var result2 = responseTask.Result;
                var readData = result2.Content.ReadAsAsync<visa>();
                if (result2.IsSuccessStatusCode)
                {
                    visa visa = readData.Result;
                    //Session["visaId"] = visa.visaId;
                    return View(visa);
                }
            }
            return View();
        }
    }
}