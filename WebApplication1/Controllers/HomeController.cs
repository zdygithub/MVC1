using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        /// <summary>
        /// 欢迎界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Welcome()
        {
            ViewBag.Message = "欢迎光临！";
            ViewBag.flag = 100;

            return View();
        }

        /// <summary>
        /// 新闻列表 
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            string[] data = new string[] { "北京再发霾黄色预警", "云南老人高速上砸石拦车：为去杭州看望外孙" , "西安榆林公交卡可刷卡消费" };
            ViewBag.data = data;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}