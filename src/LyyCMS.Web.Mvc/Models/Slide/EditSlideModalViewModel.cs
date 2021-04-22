using Abp.AutoMapper;
using LyyCMS.Slides.Dtos;

namespace LyyCMS.Web.Models.Slide
{
    [AutoMapFrom(typeof(GetSlideForEditOut))]
    public class EditSlideModalViewModel : GetSlideForEditOut //, IPermissionsEditViewModel
    {
    }
}
