using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KinoApp.Areas.Kino.Models;
using KinoApp.Areas.Kino.DAL;
using KinoApp.Areas.Kino.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KinoApp.Areas.Kino.Controllers
{
    public class MainController : Controller
    {
        // GET: Kino/Main
        KinoContext dtBase = new KinoContext();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult StartPage()
        {
            ViewData["nowDate"] = DateTime.Now.Date.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogginIntoService(string loggin, string pass)
        {
            string[] tmpTab = dtBase.LogginData(loggin, pass);
            if(!string.IsNullOrEmpty(tmpTab[0]) && !string.IsNullOrEmpty(tmpTab[1]))
            {
                int Id;
                int.TryParse(tmpTab[2], out Id);
                var data = new { Communicat = "Loggin succesfull!", Id, status = true};
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else if(string.IsNullOrEmpty(tmpTab[0]) && !string.IsNullOrEmpty(tmpTab[1]))
            {

                var data = new { Communicat = "Loggin is incorect!", status = false };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else if(!string.IsNullOrEmpty(tmpTab[0]) && string.IsNullOrEmpty(tmpTab[1]))
            {

                var data = new { Communicat = "Password is incorect!", status = false };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {

                var data = new { Communicat = "No user with this password and loggin, create new account", status = false };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public void CreateNewAccount(string json)
        {
            var deserialize = JsonSerializer.Deserialize<Users>(json);
            deserialize.UserId = dtBase.CountUsers() + 1;
            dtBase.AddUsers(deserialize);

        }
    }
}