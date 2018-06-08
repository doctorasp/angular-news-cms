using NewsBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace NewsBlog.Interfaces
{
    interface IAdmin
    {
        Task<JsonResult> GetArticles();
        Task<JsonResult> GetArticlesByFilter(string filter);
        Article GetArticle(int id);
        Task<JsonResult> GetCategories();
        ActionResult setAprovedArticle(int id);
    }
}
