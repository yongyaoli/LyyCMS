using Abp.Application.Services;
using Abp.Domain.Repositories;
using Castle.Core.Logging;
using LyyCMS.Slides.Dtos;

namespace LyyCMS.Slides
{
    public class SlideItemAppService : 
        AsyncCrudAppService<SlideItem, SlideItemDto, int, PagedSlideItemResultDto, CreateSlideItemDto, SlideItemDto, SlideItemListDto>,
        ISlideItemAppService
    {

        private readonly IRepository<SlideItem> _resposotory;
        private readonly IRepository<Slide> _slideRepository;

        public SlideItemAppService(IRepository<SlideItem> repository, IRepository<Slide> slideRepository) : base(repository)
        {
            _resposotory = repository;
            _slideRepository = slideRepository;
            Logger = NullLogger.Instance;
        }

    }
}
