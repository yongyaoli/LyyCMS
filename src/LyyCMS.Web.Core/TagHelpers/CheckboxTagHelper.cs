using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace LyyCMS.TagHelpers
{
    /// <summary>
    /// 复选框
    /// </summary>
    /// <remarks>
    /// 当Items为空时显示单个，且选择后值为true
    /// </remarks>
    [HtmlTargetElement(CheckboxTagName)]
    public class CheckboxTagHelper : TagHelper
    {

        private const string CheckboxTagName = "cl-checkbox";
        private const string ForAttributeName = "asp-for";
        private const string ItemsAttributeName = "asp-items";
        private const string SkinAttributeName = "asp-skin";
        private const string SignleTitleAttributeName = "asp-title";
        protected IHtmlGenerator Generator { get; }
        public CheckboxTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(ItemsAttributeName)]
        public IEnumerable<SelectListItem> Items { get; set; }

        [HtmlAttributeName(SkinAttributeName)]
        public CheckboxSkin Skin { get; set; } = CheckboxSkin.默认;

        [HtmlAttributeName(SignleTitleAttributeName)]
        public string SignleTitle { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //获取绑定的生成的Name属性
            string inputName = ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(For?.Name);
            string skin = string.Empty;
            #region 风格
            switch (Skin)
            {
                case CheckboxSkin.默认:
                    skin = "";
                    break;
                case CheckboxSkin.原始:
                    skin = "primary";
                    break;
            }
            #endregion
            #region 单个复选框
            if (Items == null)
            {
                output.TagName = "input";
                output.TagMode = TagMode.SelfClosing;
                output.Attributes.Add("type", "checkbox");
                output.Attributes.Add("id", inputName);
                output.Attributes.Add("name", inputName);
                output.Attributes.Add("lay-skin", skin);
                output.Attributes.Add("title", SignleTitle);
                output.Attributes.Add("value", "true");
                if (For?.Model?.ToString().ToLower() == "true")
                {
                    output.Attributes.Add("checked", "checked");
                }
                return;
            }
            #endregion
            #region 复选框组
            var currentValues = Generator.GetCurrentValues(ViewContext, For.ModelExplorer, expression: For.Name, allowMultiple: true);
            foreach (var item in Items)
            {
                var checkbox = new TagBuilder("input");
                checkbox.TagRenderMode = TagRenderMode.SelfClosing;
                checkbox.Attributes["type"] = "checkbox";
                checkbox.Attributes["id"] = inputName;
                checkbox.Attributes["name"] = inputName;
                checkbox.Attributes["lay-skin"] = skin;
                checkbox.Attributes["title"] = item.Text;
                checkbox.Attributes["value"] = item.Value;
                if (item.Disabled)
                {
                    checkbox.Attributes.Add("disabled", "disabled");
                }
                if (item.Selected || (currentValues != null && currentValues.Contains(item.Value)))
                {
                    checkbox.Attributes.Add("checked", "checked");
                }

                output.Content.AppendHtml(checkbox);
            }
            output.TagName = "";
            #endregion
        }
    }

    public enum CheckboxSkin
    {
        默认,
        原始
    }
}
