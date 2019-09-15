using System;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Extensions for the factory provider.
    /// </summary>
    public static class FactoryProviderExtensions
    {
        /// <summary>
        /// Gets typed builder from the provider with the specified identifier.
        /// <para>
        /// The type of the builder represents the identifier of the factory collection and factory id.
        /// </para>
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="builderId">The identifier of the builder.</param>
        public static TBuilder GetBuilder<TBuilder, TBuilderId>(this IFactoryProvider provider, TBuilderId builderId) where TBuilder : IBuilder
        {
            return GetBuilder<TBuilder, Type, TBuilderId>(provider, typeof(TBuilder), builderId);
        }

        /// <summary>
        /// Gets builder from the provider by the specified factory identifier and builder identifier.
        /// <para>
        /// The type of the factory identifier represents the identifier of the factory collection.
        /// </para>
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="factoryId">The identifier of the factory.</param>
        /// <param name="builderId">The identifier of the builder.</param>
        public static TBuilder GetBuilder<TBuilder, TFactoryId, TBuilderId>(this IFactoryProvider provider, TFactoryId factoryId, TBuilderId builderId) where TBuilder : IBuilder
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            IFactoryCollection<TFactoryId> collection = provider.Get<TFactoryId>();
            var factory = collection.Get<IFactory<TBuilderId>>(factoryId);

            return factory.Get<TBuilder>(builderId);
        }

        /// <summary>
        /// Tries to get typed builder from the provider with the specified identifier.
        /// <para>
        /// The type of the builder represents the identifier of the factory collection and factory id.
        /// </para>
        /// <para>
        /// Returns true if the builder was found, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="builderId">The identifier of the builder.</param>
        /// <param name="builder">The found builder.</param>
        public static bool TryGetBuilder<TBuilder, TBuilderId>(this IFactoryProvider provider, TBuilderId builderId, out TBuilder builder) where TBuilder : IBuilder
        {
            return TryGetBuilder(provider, typeof(TBuilder), builderId, out builder);
        }

        /// <summary>
        /// Tries to get builder from the provider by the specified factory identifier and builder identifier.
        /// <para>
        /// The type of the factory identifier represents the identifier of the factory collection.
        /// </para>
        /// <para>
        /// Returns true if the builder was found, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="factoryId">The identifier of the factory.</param>
        /// <param name="builderId">The identifier of the builder.</param>
        /// <param name="builder">The found builder.</param>
        public static bool TryGetBuilder<TBuilder, TFactoryId, TBuilderId>(this IFactoryProvider provider, TFactoryId factoryId, TBuilderId builderId, out TBuilder builder) where TBuilder : IBuilder
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            if (provider.TryGet(out IFactoryCollection<TFactoryId> collection) && collection.TryGet(factoryId, out IFactory<TBuilderId> factory))
            {
                if (factory.TryGet(builderId, out IBuilder value) && value is TBuilder result)
                {
                    builder = result;
                    return true;
                }
            }

            builder = default;
            return false;
        }
    }
}
