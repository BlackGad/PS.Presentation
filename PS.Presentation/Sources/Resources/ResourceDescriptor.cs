using System;

namespace PS.Presentation.Resources
{
    public class ResourceDescriptor
    {
        #region Constructors

        public ResourceDescriptor(Uri resourceDictionary, Type resourceType, string description = null)
        {
            Description = description;
            ResourceDictionary = resourceDictionary;
            ResourceType = resourceType;
        }

        #endregion

        #region Properties

        public string Description { get; }
        public Uri ResourceDictionary { get; }

        public Type ResourceType { get; }

        #endregion
    }
}