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
    public class VisaCancellationController : Controller
    {
        // GET: Visa_Cancellation
        DbValidation V = new DbValidation();
        public ActionResult VisaCancellation()
        {
            ViewBag.aclist = V.GetActiveVisaCountries(Session["userId"].ToString());
            ViewBag.userId = Session["userId"].ToString();
            ViewBag.passportId = Session["passportId"].ToString();
            //ViewBag.visaId = Session["visaId"].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult VisaCancellation(visa v)
        {
            ViewBag.aclist = V.GetActiveVisaCountries(Session["userId"].ToString());

            ViewBag.userId = Session["userId"].ToString();
            ViewBag.passportId = Session["passportId"].ToString();
            //ViewBag.visaId = Session["visaId"].ToString();
            string res = "";
            v.userId = Session["userId"].ToString();
            v.passportId = Session["passportId"].ToString();
            v.visaId = V.GetVisaIdByCountry(v.country);
            
            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri("https://pvsmback.azurewebsites.net/api/");
                var responseTask = client2.PostAsJsonAsync<visa>("VisaCancellation/CancelVisa", v);
                responseTask.Wait();
                var result2 = responseTask.Result;
                var readData = result2.Content.ReadAsAsync<string>();
                if (result2.IsSuccessStatusCode)
                {
                    res = readData.Result;
                    ViewBag.msg = res;
                    return View();
                }
                else
                {
                    res = readData.Result;
                    ViewBag.msg = res;
                    return View();
                }
            }
        }
    }
}