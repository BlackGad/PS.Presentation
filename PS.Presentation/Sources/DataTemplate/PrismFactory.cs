using System;

namespace PS.Presentation.DataTemplate
{
    public static class PrismFactory
    {
        #region Static members

        public static object GetInstance(Type serviceType, string key)
        {
            var factoryFunc = _factoryFunc;
            if (factoryFunc == null) throw new InvalidOperationException("Prism factory not registered");
            return factoryFunc(serviceType, key);
        }

        public static T GetInstance<T>(Type serviceType, string key)
        {
            return (T)GetInstance(serviceType, key);
        }

        public static void Register(Func<Type, string, object> factoryFunc)
        {
            if (factoryFunc == null) throw new ArgumentNullException(nameof(factoryFunc));
            _factoryFunc = factoryFunc;
        }

        #endregion

        private static Func<Type, string, object> _factoryFunc;
    }
}