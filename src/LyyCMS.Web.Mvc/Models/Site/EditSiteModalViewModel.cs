using Abp.AutoMapper;
using LyyCMS.Sites.Dtos;

namespace LyyCMS.Web.Models.Site
{
    public class EditSiteModalViewModel
    {

        public SiteDto Site { get; set; }

        public ChannelListDto channelList { get; set; }
    }
}
