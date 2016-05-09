using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ActiveEdge.Infrastructure.MVC
{
  public static class ViewDataExtensions
  {
    public static Dictionary<string, object> OptionalAttributes<T>(this ViewDataDictionary<T> viewData, Dictionary<string, object> additionalAttributes = null)
    {
      const string key = "AdditionalHtml";
      var optionalAttributes = new Dictionary<string, object>();
      if (viewData.ModelMetadata.AdditionalValues.ContainsKey(key))
      {
        var additionalHtml = (AdditionalHtmlAttribute) viewData.ModelMetadata.AdditionalValues[key];
        optionalAttributes = additionalHtml.OptionalAttributes();
        
      }

      if (additionalAttributes == null) return optionalAttributes;

      foreach (var additionalAttribute in additionalAttributes)
      {
        optionalAttributes.Add(additionalAttribute.Key, additionalAttribute.Value);
      }
      
      return optionalAttributes;
    }
  }
  public class AdditionalHtmlAttribute : Attribute
  {
    public string PlaceHolder { get; set; }

    public Dictionary<string, object> OptionalAttributes()
    {
      var options = new Dictionary<string, object>();

      if (string.IsNullOrEmpty(PlaceHolder) == false)
      {
        options.Add("placeholder", PlaceHolder);
      }

      return options;
    }
  }

  public class MetadataProvider : DataAnnotationsModelMetadataProvider
  {
    /// <summary>Gets the metadata for the specified property.</summary>
    /// <returns>The metadata for the property.</returns>
    /// <param name="attributes">The attributes.</param>
    /// <param name="containerType">The type of the container.</param>
    /// <param name="modelAccessor">The model accessor.</param>
    /// <param name="modelType">The type of the model.</param>
    /// <param name="propertyName">The name of the property.</param>
    protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType,
      Func<object> modelAccessor, Type modelType,
      string propertyName)
    {
      var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

      var additionalValue = attributes.OfType<AdditionalHtmlAttribute>().FirstOrDefault();

      if (additionalValue != null)
      {
        metadata.AdditionalValues.Add("AdditionalHtml", additionalValue);
      }

      return metadata;
    }
  }
}