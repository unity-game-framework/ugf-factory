using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    public static class FactoryProviderExtensions
    {
        public static TBuilder Get<T, TBuilder>(this IFactoryProvider provider, T factoryId, T builderId) where TBuilder : IBuilder
        {
            var factoryProvider = (IFactoryProvider<T>)provider;
            var factory = factoryProvider.Get<IFactory<T>>(factoryId);

            return factory.Get<TBuilder>(builderId);
        }
    }
}