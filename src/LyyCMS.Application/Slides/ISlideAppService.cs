using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LyyCMS.Slides.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Slides
{
    public interface ISlideAppService : 
        IAsyncCrudAppService<SlideDto, int, PagedSlideResultDto, CreateSlideDto, SlideDto, SlideListDto>
    {

        Task DeleteEntityAsync(EntityDto<int> entity);
    }
}
