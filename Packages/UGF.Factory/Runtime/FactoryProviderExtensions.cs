using System;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    public static class FactoryProviderExtensions
    {
        public static IFactory<TBuilderId> Add<TBuilder, TBuilderId>(this IFactoryProvider<Type> provider, TBuilderId builderId, IBuilder<TBuilder> builder)
        {
            if (!provider.TryGet<IFactory<TBuilderId>>(typeof(TBuilder), out var factory))
            {
                factory = new Factory<TBuilderId>();

                provider.Add(typeof(TBuilder), factory);
            }

            factory.Add(builderId, builder);
            
            return factory;
        }

        public static bool Remove<TBuilder, TBuilderId>(this IFactoryProvider<Type> provider, TBuilderId builderId)
        {
            if (provider.TryGet<IFactory<TBuilderId>>(typeof(TBuilder), out var factory))
            {
                factory.Remove(builderId);
                return true;
            }
            
            return false;
        }

        public static TBuilder GetBuilder<TBuilder, TBuilderId>(this IFactoryProvider<Type> provider, TBuilderId builderId) where TBuilder : IBuilder
        {
            return provider.Get<IFactory<TBuilderId>>(typeof(TBuilder)).Get<TBuilder>(builderId);
        }

        public static TBuilder GetBuilder<TBuilder, TFactoryId, TBuilderId>(this IFactoryProvider<TFactoryId> provider, TFactoryId factoryId, TBuilderId builderId) where TBuilder : IBuilder
        {
            return provider.Get<IFactory<TBuilderId>>(factoryId).Get<TBuilder>(builderId);
        }

        public static IBuilder GetBuilder<TFactoryId, TBuilderId>(this IFactoryProvider<TFactoryId> provider, TFactoryId factoryId, TBuilderId builderId)
        {
            return provider.Get<IFactory<TBuilderId>>(factoryId)[builderId];
        }
    }
}