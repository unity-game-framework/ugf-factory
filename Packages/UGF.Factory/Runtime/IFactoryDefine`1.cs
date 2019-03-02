namespace UGF.Factory.Runtime
{
    public interface IFactoryDefine<TFactoryId, TBuilderId> : IFactoryDefine
    {
        void Register(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection, IFactory<TBuilderId> factory);
        TFactoryId GetFactoryId(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);
    }
}