using System;
using System.Windows;
using System.Windows.Controls;
using PS.Presentation.Resources;

namespace Example.LazyControlDefinition.Controls
{
    public class LazyControl : Control
    {
        #region Constructors

        static LazyControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LazyControl), new FrameworkPropertyMetadata(typeof(LazyControl)));
            ResourceHelper.SetDefaultStyle(typeof(LazyControl), Resource.ControlStyle);
        }

        #endregion

        #region Nested type: Resource

        public static class Resource
        {
            #region Constants

            private static readonly Uri Default =
                new Uri("/Example.LazyControlDefinition;component/Controls/LazyControl.xaml", UriKind.RelativeOrAbsolute);

            public static readonly ResourceDescriptor ControlStyle =
                ResourceDescriptor.Create<Style>(description: "Default LazyControl style",
                                                 resourceDictionary: Default);

            public static readonly ResourceDescriptor ControlTemplate =
                ResourceDescriptor.Create<ControlTemplate>(description: "Default LazyControl control template",
                                                           resourceDictionary: Default);

            #endregion
        }

        #endregion
    }
}