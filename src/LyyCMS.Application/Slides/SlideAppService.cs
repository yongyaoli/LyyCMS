using Abp.Application.Services;
using Abp.Domain.Repositories;
using Castle.Core.Logging;
using LyyCMS.Slides.Dtos;

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


    }
}
