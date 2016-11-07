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
        public ActionResult Index(string q)
        {
            var db = new BlogDatabase();
            db.Database.CreateIfNotExists();//创建数据库

            var lst = db.BlogArticles.AsQueryable();

            if(!string.IsNullOrWhiteSpace(q))
            {
                lst = lst.Where(o => o.Subject.Contains(q));
            }

            ViewBag.BlogArticles = lst.OrderByDescending(o=>o.Subject).ToList();
            ViewBag.q = q;

            return View();
        }

        /// <summary>
        /// 显示博文列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            ViewData.Model = article;

            return View();
        }

        /// <summary>
        /// 添加新博文界面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddArticle()
        {
            return View();
        }

        /// <summary>
        /// 保存要添加的博文
        /// </summary>
        /// <returns></returns>
        public ActionResult ArticleSave(BlogArticle model)
        {
            var article = new BlogArticle();
            article.Subject = model.Subject;
            article.Body = model.Body;
            article.DateCreated = DateTime.Now;

            var db = new BlogDatabase();
            db.BlogArticles.Add(article);
            db.SaveChanges();

            //return Redirect("Index");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 编辑博文界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var db =new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            ViewData.Model = article;

            return View();
        }

        /// <summary>
        /// 保存编辑后的博文
        /// </summary>
        /// <returns></returns>
        public ActionResult EditSave(BlogArticle model)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == model.Id);

            article.Subject = model.Subject;
            article.Body = model.Body;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            db.BlogArticles.Remove(article);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}