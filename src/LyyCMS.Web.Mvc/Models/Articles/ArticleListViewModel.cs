using LyyCMS.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Models.Articles
{
    public class ArticleListViewModel
    {

        public IReadOnlyList<ArticleCategoryListDto> CategoryList { get; set; }
    }
}
