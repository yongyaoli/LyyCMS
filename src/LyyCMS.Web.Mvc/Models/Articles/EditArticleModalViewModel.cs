using LyyCMS.Articles.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LyyCMS.Web.Models.Articles
{
    public class EditArticleModalViewModel
    {

        public ArticleDto Article { get; set; }

        public List<ArticleCategoryListDto> ArticleCategory { get; set; }


        public IEnumerable<SelectListItem> Categories { get; set; }

        public bool ArticleInCategory(ArticleCategoryListDto categoryDto)
        {
            return Article.category != null && Article.articleCategoryId == categoryDto.Id;
        }
    }
}
