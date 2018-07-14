using System;
using System.Windows;
using PS.Presentation.DataTemplate;

namespace Example.PrismDataTemplate
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Override members

        protected override void OnStartup(StartupEventArgs e)
        {
            //It is simplified usage.
            //Use any existing dependency resolver here in your application (ServiceLocator.Current.GetInstance() or MEF/Unity container resolver for example)
            PrismFactory.Register((serviceType, key) => Activator.CreateInstance(serviceType));

            base.OnStartup(e);
        }

        #endregion
    }
}