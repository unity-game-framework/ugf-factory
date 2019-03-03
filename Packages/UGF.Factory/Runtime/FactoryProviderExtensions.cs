using System;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    public static class FactoryProviderExtensions
    {
        public static TBuilder GetBuilder<TBuilder, TBuilderId>(this IFactoryProvider provider, TBuilderId builderId) where TBuilder : IBuilder
        {
            return GetBuilder<TBuilder, Type, TBuilderId>(provider, typeof(TBuilder), builderId);
        }
        
        public static TBuilder GetBuilder<TBuilder, TFactoryId, TBuilderId>(this IFactoryProvider provider, TFactoryId factoryId, TBuilderId builderId) where TBuilder : IBuilder
        {
            IFactoryCollection<TFactoryId> collection = provider.Get<TFactoryId>();
            var factory = collection.Get<IFactory<TBuilderId>>(factoryId);

            return factory.Get<TBuilder>(builderId);
        }
    }
}