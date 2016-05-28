using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace ActiveEdge.Infrastructure.Extensions
{
    public static class ViewDataExtensions
    {
        public static IDictionary<string, object> GetDefaultEditorAttributes(this ViewDataDictionary viewData)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(viewData["htmlAttributes"]);

            if (attributes.ContainsKey("class"))
            {
                attributes["class"] = $"form-control {attributes["class"]}";
            }
            else
            {
                attributes["class"] = "form-control";
            }

            //if (viewData.ModelMetadata.AdditionalValues.ContainsKey("size"))
            //{
            //    var size = (int) viewData.ModelMetadata.AdditionalValues["size"];
            //    attributes["size"] = size;
            //    attributes["class"] = $"{attributes["class"]} col-xs-{size}";
            //}

            if (viewData.ModelMetadata.IsReadOnly)
            {
                attributes.Add("readonly", "");
            }

            if (viewData.ModelMetadata.IsRequired)
            {
                attributes["class"] += " required";
            }
            if (viewData.ModelMetadata.AdditionalValues.ContainsKey("placeholder"))
            {
                attributes.Add("placeholder", viewData.ModelMetadata.AdditionalValues["placeholder"] as string);
            }

            var newAttributes = new Dictionary<string, object>();
            foreach (var attribute in attributes)
            {
                newAttributes.Add(attribute.Key == "databindKO" ? "data-bind" : attribute.Key, attribute.Value);
            }

            return newAttributes;
        }
    }
}