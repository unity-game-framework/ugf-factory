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
        /// Adds builder into the provider by the specified factory and builder identifiers.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="builderId">The identifier of the builder.</param>
        /// <param name="handler">The builder handler.</param>
        public static void AddBuilder<TResult, TBuilderId>(this IFactoryProvider provider, TBuilderId builderId, Func<TResult> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            var builder = new BuilderFunc<TResult>(handler);

            AddBuilder(provider, typeof(TResult), builderId, builder);
        }

        /// <summary>
        /// Adds builder into the provider by the specified factory and builder identifiers.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="builderId">The identifier of the builder.</param>
        /// <param name="builder">The builder to add.</param>
        public static void AddBuilder<TResult, TBuilderId>(this IFactoryProvider provider, TBuilderId builderId, IBuilder builder)
        {
            AddBuilder(provider, typeof(TResult), builderId, builder);
        }

        /// <summary>
        /// Adds builder into the provider by the specified factory and builder identifiers.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="factoryId">The identifier of the factory.</param>
        /// <param name="builderId">The identifier of the builder.</param>
        /// <param name="builder">The builder to add.</param>
        public static void AddBuilder<TFactoryId, TBuilderId>(this IFactoryProvider provider, TFactoryId factoryId, TBuilderId builderId, IBuilder builder)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            if (!provider.TryGet(out IFactoryCollection<TFactoryId> collection))
            {
                collection = new FactoryCollection<TFactoryId>();

                provider.Add(collection);
            }

            if (!collection.TryGet(factoryId, out IFactory<TBuilderId> factory))
            {
                factory = new Factory<TBuilderId>();

                collection.Add(factoryId, factory);
            }

            factory.Add(builderId, builder);
        }

        /// <summary>
        /// Removes builder from the provider by the specified factory and builder identifiers.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="factoryId">The identifier of the factory.</param>
        /// <param name="builderId">The identifier of the builder.</param>
        public static void RemoveBuilder<TFactoryId, TBuilderId>(this IFactoryProvider provider, TFactoryId factoryId, TBuilderId builderId)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            if (provider.TryGet(out IFactoryCollection<TFactoryId> collection) && collection.TryGet(factoryId, out IFactory<TBuilderId> factory))
            {
                factory.Remove(builderId);
            }
        }

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
