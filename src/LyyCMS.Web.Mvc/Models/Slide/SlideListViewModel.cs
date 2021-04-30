using LyyCMS.Slides;
using LyyCMS.Slides.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Models.Slide
{
    public class SlideListViewModel
    {
        public SlideDto Slide { get; set; }
        public ICollection<SlideItem> SlideItems { get; set; }
    }
}
