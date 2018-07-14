using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PS.Presentation.Extensions.PrismDataTemplateExample.Extensions;

namespace PS.Presentation.DataTemplate.Base
{
    public class CustomFrameworkElementFactory : FrameworkElementFactory
    {
        #region Static members

        public static void SetViewDataContext(FrameworkElement view, object context)
        {
            var payloadViewModel = view?.DataContext as IPayloadContainer;
            if (payloadViewModel != null) payloadViewModel.Payload = context;
        }

        #endregion

        private readonly ICustomDataTemplate _customDataTemplate;

        #region Constructors

        public CustomFrameworkElementFactory(ICustomDataTemplate customDataTemplate)
            : base(typeof(Control))
        {
            if (customDataTemplate == null) throw new ArgumentNullException(nameof(customDataTemplate));
            _customDataTemplate = customDataTemplate;

            OverrideDefaultFactory();
        }

        #endregion

        #region Event handlers

        private void container_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var container = sender as ContentPresenter;
            if (container == null || VisualTreeHelper.GetChildrenCount(container) == 0) return;

            var view = VisualTreeHelper.GetChild(container, 0) as FrameworkElement;
            SetViewDataContext(view, container.DataContext);
        }

        private void LoadedRoutedEventHandler(object sender, RoutedEventArgs e)
        {
            var container = (FrameworkElement)sender;
            container.DataContextChanged += container_DataContextChanged;

            if (VisualTreeHelper.GetChildrenCount(container) == 0) return;

            var view = VisualTreeHelper.GetChild(container, 0) as FrameworkElement;
            SetViewDataContext(view, container.DataContext);
        }

        private void UnloadedRoutedEventHandler(object sender, RoutedEventArgs e)
        {
            var container = (FrameworkElement)sender;
            container.DataContextChanged -= container_DataContextChanged;
        }

        #endregion

        #region Members

        internal void OverrideDefaultFactory()
        {
            var field = typeof(FrameworkElementFactory).GetField("_knownTypeFactory", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null) throw new NotSupportedException();
            field.SetValue(this, new Func<object>(CreateViewInstance));
        }

        private object CreateViewInstance()
        {
            if (this.IsInDesignMode())
            {
                var designTimeBlankContainer = new Grid
                {
                    Background = new SolidColorBrush(Color.FromArgb(50, 120, 120, 120)),
                };
                if (_customDataTemplate.DesignWidth.HasValue) designTimeBlankContainer.Width = _customDataTemplate.DesignWidth.Value;
                if (_customDataTemplate.DesignHeight.HasValue) designTimeBlankContainer.Height = _customDataTemplate.DesignHeight.Value;

                var formatText = _customDataTemplate.Description;
                designTimeBlankContainer.Children.Add(new TextBlock
                {
                    Text = formatText,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                return designTimeBlankContainer;
            }

            var container = new ContentPresenter
            {
                Content = _customDataTemplate.CreateView()
            };
            container.AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(LoadedRoutedEventHandler));
            container.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(UnloadedRoutedEventHandler));

            return container;
        }

        #endregion
    }
}