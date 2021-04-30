using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Castle.Core.Logging;
using LyyCMS.Slides.Dtos;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LyyCMS.Slides
{
    public class SlideAppService :
         AsyncCrudAppService<Slide, SlideDto, int, PagedSlideResultDto, CreateSlideDto, SlideDto, SlideListDto>,
        ISlideAppService
    {
        private readonly IRepository<Slide> _resposotory;
        private readonly IRepository<SlideItem> _itemRepository;

        public SlideAppService(IRepository<Slide> repository, IRepository<SlideItem> itemRepository) : base(repository)
        {
            _resposotory = repository;
            _itemRepository = itemRepository;
            Logger = NullLogger.Instance;
        }

        public async Task DeleteEntityAsync(EntityDto<int> entity)
        {
            var slide = await Repository.GetAllIncluding(x => x.SlideItems).FirstOrDefaultAsync(x => x.Id == entity.Id);
            //var slide = await GetEntityByIdAsync(entity.Id);
            if (null == slide)
            {
                throw new UserFriendlyException("数据不存在");
            }
            var items = slide.SlideItems;
            if (items.Count > 0)
            {
                throw new UserFriendlyException("需要先删除幻灯片图片");
            }
            await _resposotory.DeleteAsync(slide);

        }
    }
}
