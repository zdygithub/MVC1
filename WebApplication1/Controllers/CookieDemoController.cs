using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CookieDemoController : Controller
    {
        // GET: CookieDemo
        public ActionResult Index()
        {
            int count1=1;

            var cookie = Request.Cookies["count2"];
            if(cookie==null)
            {
                Response.Cookies.Add(new HttpCookie("count2", "1"));
            }
            else
            {
                count1 = int.Parse(cookie.Value) + 1;
                var newcookie = new HttpCookie("count2", count1.ToString());
                newcookie.Expires = DateTime.Now.AddSeconds(10);
                Response.Cookies.Add(newcookie);
            }

            ViewBag.count = count1;
            return View();
        }
    }
}