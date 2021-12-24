using LyyCMS.Slides.Dtos;
using LyyCMS.Slides;
using System.Collections.Generic;
using LyyCMS.Sites.Dtos;
using LyyCMS.Sites;

namespace LyyCMS.Web.Models.Site
{
    public class SiteListViewModel
    {
        public IReadOnlyList<SiteDto> Sites { get; set; }

    }
}
