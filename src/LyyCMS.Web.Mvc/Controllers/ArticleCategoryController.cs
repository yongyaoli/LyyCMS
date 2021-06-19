using Abp.Application.Services.Dto;
using LyyCMS.Articles;
using LyyCMS.Articles.Dtos;
using LyyCMS.Controllers;
using LyyCMS.Web.Models.Articles;
using LyyCMS.Web.Models.Tree;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
    public class ArticleCategoryController : LyyCMSControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IArticleCategoryAppService _categoryAppService;

        public ArticleCategoryController(
            IWebHostEnvironment webHostEnvironment,
            IArticleCategoryAppService categoryAppService)
        {
            _webHostEnvironment = webHostEnvironment;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            var articleCategories = await _categoryAppService.GetAllArticleCategoryListAsync();

            List<ArticleCategoryListDto> afterCategory = new List<ArticleCategoryListDto>();

            sort(0, articleCategories, afterCategory);

            var model = new ArticleCategoryListViewModel
            {
                ParentCategoryList = articleCategories,
                TreeData = afterCategory
            };

            

            return View(model);
        }

        /// <summary>
        /// 返回JSON 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetArticleCategory()
        {
            //var articleCategories = _categoryAppService.GetAllArticleCategoryList();

            //List <ArticleCategoryListDto> afterCategory = new List<ArticleCategoryListDto>();

            //sort(0, articleCategories, afterCategory);
            //return Json(afterCategory);

            IList<TreeData> treeDatas = GetData();

            return Json(treeDatas);
        }




        public IList<TreeData> GetData()
        {
            var articleCategories = _categoryAppService.GetAllArticleCategoryList();
            List<TreeData> nodes = articleCategories.Where(x => x.ParentId == 0).Select(x => new TreeData { id = x.Id, pId = x.ParentId, name = x.Name }).ToList();
            foreach (TreeData item in nodes)
            {
                item.children = GetChildrens(item, articleCategories);
            }
            return nodes;
        }
        //递归获取子节点
        public IList<TreeData> GetChildrens(TreeData node,List<ArticleCategoryListDto> articleCategories)
        {
            IList<TreeData> childrens = articleCategories.Where(c => c.ParentId == node.id).Select(x => new TreeData { id = x.Id, pId = x.ParentId, name = x.Name }).ToList();
            foreach (TreeData item in childrens)
            {
                item.children = GetChildrens(item, articleCategories);
            }
            return childrens;
        }




        public async Task<ActionResult> EditModal(int id)
        {
            var articleCategory = await _categoryAppService.GetAsync(new EntityDto<int>(id));

            PagedArticleCategoryResultRequestDto dto = new PagedArticleCategoryResultRequestDto();
            dto.MaxResultCount = int.MaxValue;
            var all = await _categoryAppService.GetAllAsync(dto);
            var allList = all.Items.Where(x => x.Id != id).ToList();

            var model = new EditArticleCategoryModalViewModel
            {
                ArticleCategory = articleCategory,
                Parents = allList
            };
            return PartialView("_EditModal", model);
        }

        /**
     *  树形结构排序
     * @param parentId  父节点ID
     * @param itemCatsBeforeList  源数据    原始查询的数据
     * @param itemCatsAfterList  目标数据   新创建的集合
     * @return
     */
        protected List<ArticleCategoryListDto> sort(int parentId, List<ArticleCategoryListDto> itemCatsBeforeList, List<ArticleCategoryListDto> itemCatsAfterList)
        {
            foreach (ArticleCategoryListDto entity in itemCatsBeforeList)
            {
                if (entity.ParentId==parentId)
                {
                    itemCatsAfterList.Add(entity);
                    sort(entity.Id, itemCatsBeforeList, itemCatsAfterList);
                }
            }
            return itemCatsAfterList;
        }


    }
}
