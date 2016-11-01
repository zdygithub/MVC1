using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            var db = new BlogDatabase();
            db.Database.CreateIfNotExists();//创建数据库

            var lst = db.BlogArticles.OrderByDescending(o => o.Id).ToList();//按指定表达式对集合倒序排序
            ViewBag.BlogArticles = lst;

            return View();
        }

        public ActionResult Show(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            ViewData.Model = article;

            return View();
        }

        public ActionResult AddArticle()
        {
            return View();
        }

        public ActionResult ArticleSave(string subject, string body)
        {
            var article = new BlogArtice();
            article.Subject = subject;
            article.Body = body;
            article.DateCreated = DateTime.Now;

            var db = new BlogDatabase();
            db.BlogArticles.Add(article);
            db.SaveChanges();

            return Redirect("Index");
        }
    }
}