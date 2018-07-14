﻿using System;
using System.Diagnostics;
using System.Management.Instrumentation;
using System.Reflection;
using System.Windows;
using PS.Presentation.Extensions.PrismDataTemplateExample.Extensions;

namespace PS.Presentation.Resources
{
    public static class ResourceHelper
    {
        #region Constants

        private static readonly MethodInfo FrameworkElementFindResourceMethod;

        #endregion

        #region Static members

        public static T GetResource<T>(this ResourceDescriptor descriptor)
        {
            return (T)GetResource(descriptor);
        }

        public static object GetResource(this ResourceDescriptor descriptor)
        {
            if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));

            var element = new FrameworkElement();
            element.Resources.MergedDictionaries.Add(new SharedResourceDictionary
            {
                Source = descriptor.ResourceDictionary
            });
            var result = element.FindResource(descriptor);
            if (descriptor.ResourceType.IsInstanceOfType(result)) return result;
            throw new InstanceNotFoundException("Resource not found");
        }

        public static void SetDefaultStyle(Type elementType, ResourceDescriptor descriptor)
        {
            if (ObjectExtensions.IsInDesignMode(null)) return;
            var stylePropertyMetadata = (FrameworkPropertyMetadata)FrameworkElement.StyleProperty.GetMetadata(elementType);
            FrameworkElement.StyleProperty.OverrideMetadata(elementType,
                                                            new FrameworkPropertyMetadata
                                                            {
                                                                PropertyChangedCallback = stylePropertyMetadata.PropertyChangedCallback,
                                                                CoerceValueCallback = stylePropertyMetadata.CoerceValueCallback,
                                                                DefaultValue = GetResource<Style>(descriptor)
                                                            });
        }

        public static void SetDefaultStyle(this FrameworkElement element, ResourceDescriptor descriptor)
        {
            if (FrameworkElementFindResourceMethod == null) throw new InvalidOperationException("Invalid framework version");
            var resource = FrameworkElementFindResourceMethod.Invoke(null, new object[] { element, null, element.GetType() });
            if (resource == DependencyProperty.UnsetValue) element.Style = GetResource<Style>(descriptor);
        }

        public static void SetDefaultStyle(this FrameworkContentElement element, ResourceDescriptor descriptor)
        {
            if (FrameworkElementFindResourceMethod == null) throw new InvalidOperationException("Invalid framework version");
            var resource = FrameworkElementFindResourceMethod.Invoke(null, new object[] { element, null, element.GetType() });
            if (resource == DependencyProperty.UnsetValue) element.Style = GetResource<Style>(descriptor);
        }

        #endregion

        #region Constructors

        static ResourceHelper()
        {
            try
            {
                FrameworkElementFindResourceMethod = typeof(FrameworkElement).GetMethod("FindResourceInternal",
                                                                                        BindingFlags.NonPublic | BindingFlags.Static,
                                                                                        null,
                                                                                        new[]
                                                                                        {
                                                                                            typeof(FrameworkElement), typeof(FrameworkContentElement),
                                                                                            typeof(object)
                                                                                        },
                                                                                        null);
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached) Debug.WriteLine(e);
            }
        }

        #endregion
    }
}