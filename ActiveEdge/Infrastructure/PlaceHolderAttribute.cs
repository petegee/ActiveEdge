using System;
using System.Web.Mvc;

namespace ActiveEdge.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PlaceHolderAttribute : Attribute
    {
        private readonly string _placeholder;

        public PlaceHolderAttribute(string placeholder)
        {
            _placeholder = placeholder;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["placeholder"] = _placeholder;
        }
    }
}