using System;
using System.Windows;
using System.Windows.Markup;
using PS.Presentation.DataTemplate.Base;
using PS.Presentation.Extensions.PrismDataTemplateExample.Extensions;

namespace PS.Presentation.DataTemplate
{
    [ContentProperty]
    public class ViewHierarchicalDataTemplate : HierarchicalDataTemplate,
                                                ICustomDataTemplate
    {
        #region Constructors

        public ViewHierarchicalDataTemplate()
        {
            VisualTree = new CustomFrameworkElementFactory(this);
            VisualTree.InternalMethodCall("Seal", this);
        }

        #endregion

        #region Properties

        public double? DesignHeight { get; set; }
        public double? DesignWidth { get; set; }

        public Type ViewType { get; set; }

        string ICustomDataTemplate.Description
        {
            get
            {
                var description = $"View of {ViewType} type template";
                return description;
            }
        }

        #endregion

        #region ICustomDataTemplate Members

        public FrameworkElement CreateView()
        {
            return Activator.CreateInstance(ViewType) as FrameworkElement;
        }

        #endregion
    }
}