namespace UGF.Factory.Runtime
{
    public interface IFactoryDefine<TFactoryId, TBuilderId> : IFactoryDefine
    {
        void RegisterBuilders(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection, IFactory<TBuilderId> factory);
        IFactory<TBuilderId> GetFactory(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);
        IFactory<TBuilderId> CreateFactory(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);   
        TFactoryId GetFactoryId(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);
    }
}