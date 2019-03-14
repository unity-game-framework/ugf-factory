using System;

namespace UGF.Factory.Runtime
{
    public abstract class FactoryDefineBase<TFactoryId, TBuilderId> : IFactoryDefine<TFactoryId, TBuilderId>
    {
        public Type FactoryIdentifierType { get; } = typeof(TFactoryId);
        public Type BuilderIdentifierType { get; } = typeof(TBuilderId);

        public abstract TFactoryId GetFactoryId(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);
        public abstract void RegisterBuilders(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection, IFactory<TBuilderId> factory);

        /// <summary>
        /// Gets the factory collection from the provider.
        /// <para>
        /// If the factory collection does not exists, will create and add to the provider.
        /// </para>
        /// </summary>
        /// <param name="provider">The factory provider to get from.</param>
        public virtual IFactoryCollection<TFactoryId> GetCollection(IFactoryProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            
            if (!provider.TryGet(out IFactoryCollection<TFactoryId> collection))
            {
                collection = CreateCollection(provider);

                provider.Add(collection);
            }

            return collection;
        }

        public virtual IFactory<TBuilderId> GetFactory(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            
            TFactoryId factoryId = GetFactoryId(provider, collection);

            if (!collection.TryGet(factoryId, out IFactory<TBuilderId> factory))
            {
                factory = CreateFactory(provider, collection);

                collection.Add(factoryId, factory);
            }

            return factory;
        }

        /// <summary>
        /// Creates the factory collection for the specified provider.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        public virtual IFactoryCollection<TFactoryId> CreateCollection(IFactoryProvider provider)
        {
            return new FactoryCollection<TFactoryId>();
        }

        public virtual IFactory<TBuilderId> CreateFactory(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection)
        {
            return new Factory<TBuilderId>();
        }

        void IFactoryDefine.RegisterBuilders(IFactoryProvider provider, IFactoryCollection collection, IFactory factory)
        {
            RegisterBuilders(provider, (IFactoryCollection<TFactoryId>)collection, (IFactory<TBuilderId>)factory);
        }

        IFactoryCollection IFactoryDefine.GetCollection(IFactoryProvider provider)
        {
            return GetCollection(provider);
        }

        IFactory IFactoryDefine.GetFactory(IFactoryProvider provider, IFactoryCollection collection)
        {
            return GetFactory(provider, (IFactoryCollection<TFactoryId>)collection);
        }

        IFactoryCollection IFactoryDefine.CreateCollection(IFactoryProvider provider)
        {
            return CreateCollection(provider);
        }

        IFactory IFactoryDefine.CreateFactory(IFactoryProvider provider, IFactoryCollection collection)
        {
            return CreateFactory(provider, (IFactoryCollection<TFactoryId>)collection);
        }
    }
}