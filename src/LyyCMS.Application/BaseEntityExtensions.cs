using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS
{
    /**
     * 没启用
     */
    public static class BaseEntityExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<T>
        (this IList<T> baseEntities) where T : FullAuditedEntity
        {
            return ToSelectListItems((IEnumerator<FullAuditedEntity>)
                       baseEntities.GetEnumerator());
        }

        public static IEnumerable<SelectListItem> ToSelectListItems
            (this IEnumerator<FullAuditedEntity> baseEntities)
        {
            var items = new HashSet<SelectListItem>();

            while (baseEntities.MoveNext())
            {
                var item = new SelectListItem();
                var entity = baseEntities.Current;

                item.Value = entity.Id.ToString();
                item.Text = entity.ToString();

                items.Add(item);
            }

            return items;
        }

        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> baseEntities) where T : FullAuditedEntity
        {

            return baseEntities.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ToString()
            });

        }
    }
}
