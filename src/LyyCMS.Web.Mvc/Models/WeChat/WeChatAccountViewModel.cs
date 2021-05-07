using LyyCMS.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyyCMS.WeChat.Dto;

namespace LyyCMS.Web.Models.WeChat
{
    public class WeChatAccountViewModel
    {

        public IReadOnlyList<WeChatAccountDto> accountList { get; set; }
    }
}
