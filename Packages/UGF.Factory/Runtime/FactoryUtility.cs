using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    public static class FactoryUtility
    {
        public static TResult Build<TResult, TFactory, TBuilder>(IFactoryProvider<TFactory> provider, TFactory factoryId, TBuilder builderId)
        {
            return GetBuilder<IBuilder<TResult>, TFactory, TBuilder>(provider, factoryId, builderId).Build();
        }

        public static TResult GetBuilder<TResult, TFactory, TBuilder>(IFactoryProvider<TFactory> provider, TFactory factoryId, TBuilder builderId) where TResult : IBuilder
        {
            return provider.Get<IFactory<TBuilder>>(factoryId).Get<TResult>(builderId);
        }
    }
}