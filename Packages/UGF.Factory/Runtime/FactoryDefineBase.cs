using System;

namespace UGF.Factory.Runtime
{
    public abstract class FactoryDefineBase<TFactoryId, TBuilderId> : IFactoryDefine<TFactoryId, TBuilderId>
    {
        public Type FactoryIdentifierType { get; } = typeof(TFactoryId);
        public Type BuilderIdentifierType { get; } = typeof(TBuilderId);

        public abstract void Register(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection, IFactory<TBuilderId> factory);
        public abstract TFactoryId GetFactoryId(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);

        public virtual IFactoryCollection<TFactoryId> GetCollection(IFactoryProvider provider)
        {
            return new FactoryCollection<TFactoryId>();
        }

        public virtual IFactory<TBuilderId> GetFactory(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection)
        {
            return new Factory<TBuilderId>();
        }

        void IFactoryDefine.Register(IFactoryProvider provider, IFactoryCollection collection, IFactory factory)
        {
            Register(provider, (IFactoryCollection<TFactoryId>)collection, (IFactory<TBuilderId>)factory);
        }

        IFactoryCollection IFactoryDefine.GetCollection(IFactoryProvider provider)
        {
            return GetCollection(provider);
        }

        IFactory IFactoryDefine.GetFactory(IFactoryProvider provider, IFactoryCollection collection)
        {
            return GetFactory(provider, (IFactoryCollection<TFactoryId>)collection);
        }
    }
}