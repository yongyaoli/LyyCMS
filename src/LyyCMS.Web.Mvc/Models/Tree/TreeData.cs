using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Models.Tree
{
    /// <summary>
    /// 树状结构(ztree)
    /// </summary>
    [Serializable]
    public class TreeData
    {
        public int id { get; set; }

        public int pId { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public bool open { get; set; }
        public IList<TreeData> children = new List<TreeData>();

        public virtual void Addchildren(TreeData node)
        {
            this.children.Add(node);
        }


    }
}
