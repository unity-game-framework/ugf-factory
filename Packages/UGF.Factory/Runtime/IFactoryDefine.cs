using System;

namespace UGF.Factory.Runtime
{
    public interface IFactoryDefine
    {
        Type FactoryIdentifierType { get; }
        Type BuilderIdentifierType { get; }

        void RegisterBuilders(IFactoryProvider provider, IFactoryCollection collection, IFactory factory);
        IFactoryCollection GetCollection(IFactoryProvider provider);
        IFactory GetFactory(IFactoryProvider provider, IFactoryCollection collection);
        IFactoryCollection CreateCollection(IFactoryProvider provider);
        IFactory CreateFactory(IFactoryProvider provider, IFactoryCollection collection);
    }
}