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
        public ActionResult List(int page=1)
        {
            string[] data = new string[] { "北京再发霾黄色预警", "云南老人高速上砸石拦车：为去杭州看望外孙" , "西安榆林公交卡可刷卡消费" };
            ViewBag.data = data;
            ViewData["data"] = data;
            ViewData.Model = data;

            ViewBag.Page = page;

            return View();
        }

        /// <summary>
        /// 添加新闻页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 保存新闻按钮
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(string title, string content)
        {
            ViewBag.Title1 = title;
            ViewBag.Content = content;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}