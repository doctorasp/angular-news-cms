using NewsBlog.Models;
using NewsBlog.Repository;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsBlog.Controllers
{
    public class AdminController : Controller
    {
        private AdminRepository _repo;

        public AdminController()
        {
            _repo = new AdminRepository();
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public async Task<JsonResult> GetArticlesByFilter(string filter)
        {
            return await _repo.GetArticlesByFilter(filter);
        }

        public async Task<JsonResult> GetArticles()
        {
            return await _repo.GetArticles();
        }
        public async Task<JsonResult> GetCategories()
        {
            return await _repo.GetCategories();
        }

        public ActionResult isAproved([Bind(Include = "isAprove")] int id)
        {
            return _repo.setAprovedArticle(id);
        }
    }
}