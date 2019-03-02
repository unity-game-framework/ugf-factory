using System;

namespace UGF.Factory.Runtime
{
    public interface IFactoryDefine
    {
        Type FactoryIdentifierType { get; }
        Type BuilderIdentifierType { get; }
        
        void Register(IFactoryProvider provider, IFactoryCollection collection, IFactory factory);
        IFactoryCollection GetCollection(IFactoryProvider provider);
        IFactory GetFactory(IFactoryProvider provider, IFactoryCollection collection);
    }
}