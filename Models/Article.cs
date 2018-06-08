using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NewsBlog.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string Content { get; set; }
        public System.DateTime DateCreate { get; set; }
        public string CoverType { get; set; }
        public int ViewCount { get; set; }
        public int CategoriesID { get; set; }
        public string UserID { get; set; }
        public bool isAprove { get; set; }
        public int CommentsCount { get; set; }
        public string CoverPath { get; set; }
        public bool isAdminChoose { get; set; }
        public bool isHotArticle { get; set; }

        public virtual Categories Categories { get; set; }
    }
}