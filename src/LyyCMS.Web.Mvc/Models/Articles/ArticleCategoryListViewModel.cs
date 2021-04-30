using LyyCMS.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Models.Articles
{
    public class ArticleCategoryListViewModel
    {

        public IReadOnlyList<ArticleCategoryListDto> ParentCategoryList { get; set; }

    }
}
