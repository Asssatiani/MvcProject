using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string lang)
        {
            if (!string.IsNullOrEmpty(lang) && (lang == "ka" || lang == "en"))
                SetLanguage(lang);

            ViewData["Lang"] = Thread.CurrentThread.CurrentCulture;
            return View();
        }

        [HttpPost]
        public void ChangeLanguage(string lang)
        {
            SetLanguage(lang);
        }


        private void SetLanguage(string lang)
        {
            if (lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

                HttpCookie cookie = new HttpCookie("_lang");
                cookie.Value = lang;
                Response.Cookies.Add(cookie);
            }
        }
    }
}