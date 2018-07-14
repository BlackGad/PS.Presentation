using System;
using System.Windows;
using System.Windows.Markup;
using PS.Presentation.DataTemplate.Base;
using PS.Presentation.Extensions.PrismDataTemplateExample.Extensions;

namespace PS.Presentation.DataTemplate
{
    [ContentProperty]
    public class PrismDataTemplate : System.Windows.DataTemplate,
                                     ICustomDataTemplate
    {
        #region Constructors

        public PrismDataTemplate()
        {
            VisualTree = new CustomFrameworkElementFactory(this);
            VisualTree.InternalMethodCall("Seal", this);
        }

        #endregion

        #region Properties

        public double? DesignHeight { get; set; }
        public double? DesignWidth { get; set; }

        public string Key { get; set; }
        public Type ServiceType { get; set; }

        string ICustomDataTemplate.Description
        {
            get
            {
                var description = $"Prism template: {ServiceType.Name}";
                if (!string.IsNullOrEmpty(Key)) description += $", {Key}";
                return description;
            }
        }

        #endregion

        #region ICustomDataTemplate Members

        public FrameworkElement CreateView()
        {
            return PrismFactory.GetInstance<FrameworkElement>(ServiceType, Key);
        }

        #endregion
    }
}