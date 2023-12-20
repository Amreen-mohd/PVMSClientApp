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
    public class PassportRenewalController : Controller
    {
        DbValidation V = new DbValidation();

        public ActionResult Renewal()
        {

            ViewBag.slist = V.validateState();
            string userId = Session["userId"].ToString();
            passport p = new passport();
            p.userId = userId;

            return View(p);
        }
        [HttpPost]
        public ActionResult Renewal(passport p)
        {
            List<city> cities = V.validateCity(p.state);
            ViewBag.slist = V.validateState();
            
            string userId = Session["userId"].ToString();
            p.userId = userId;
            p.country = "India";
            if (ModelState.IsValid)
            {
                string res = "";
                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri("https://localhost:44386/api/");
                    var responseTask = client2.PostAsJsonAsync<passport>("PassportRenewal/Renewal", p);
                    responseTask.Wait();
                    var result2 = responseTask.Result;
                    var readData = result2.Content.ReadAsAsync<string>();
                    if (result2.IsSuccessStatusCode)
                    {
                        res = readData.Result;
                        ViewBag.msg = "passport renewal successfull";
                        return RedirectToAction("Success","PassportReg",p);
                        //return View(p);
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
        public JsonResult getcities(string sId)
        {
            List<city> cities = V.validateCity(sId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

    }
}