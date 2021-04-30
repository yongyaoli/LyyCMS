using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Models.Articles
{
    public class CreateArticleViewModel
    {
        public string title { get; set; }

        public int articleCategoryId { get; set; }


        public string content { get; set; }

        public bool top { get; set; }

        public bool red { get; set; }

        public bool comment { get; set; }

        public int comment_count { get; set; }

        public int hit { get; set; }

        public int favorite { get; set; }

        public string source { get; set; }

        public string thumbnail { get; set; }

        public int status { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
