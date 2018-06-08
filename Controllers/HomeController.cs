using NewsBlog.Models;
using PagedList;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace NewsBlog.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public static int Counter { get; set; }

        [HttpGet]
        public ActionResult AjaxMostPopular()
        {
            var model = (from a in db.Articles orderby a.ViewCount descending select a).Where(x=>x.isAprove==true).Take(3);
            Counter = 2;
            return PartialView("_AjaxMostPopular", model);
        }

        [HttpPost]
        [ActionName("AjaxMostPopular")]
        public ActionResult PartialGridPost(int count = 3)
        {
            count = count + Counter;
            var model = (from a in db.Articles orderby a.ViewCount descending select a).Where(x=>x.isAprove==true).Take(count);
            Counter += 2;
            return PartialView("_AjaxMostPopular", model);
        }

        [AllowAnonymous]
        [OutputCache(Location=System.Web.UI.OutputCacheLocation.Any, Duration=60)]
        public FileContentResult GetUserImage(string id)
        {
            var cover = db.Users.FirstOrDefault(p => p.Id == id);
            if (cover.Cover != null && cover.CoverType!=null)
            {
                return File(cover.Cover, cover.CoverType);
            }
            else
            {
                string imageFile = System.Web.HttpContext.Current.Server.MapPath("~/Content/user.png");
                var srcImage = Image.FromFile(imageFile);
                var stream = new MemoryStream();
                srcImage.Save(stream, ImageFormat.Png);
                return File(stream.ToArray(), "image/png");
            }
        }

        [AllowAnonymous]
        public ActionResult news([Bind(Include = "ViewCount")] int? id)
        {
            Article article = db.Articles.Find(id);
            
            if (article != null)
            {
                article.ViewCount += 1;
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return View("article", article);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Index()
        {
            ViewBag.S = TempData["message"] as string;
            return View();
        }
    }
    }