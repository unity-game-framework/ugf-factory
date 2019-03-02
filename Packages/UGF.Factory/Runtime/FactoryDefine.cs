using System;

namespace UGF.Factory.Runtime
{
    public abstract class FactoryDefine<TFactory, TBuilderId> : FactoryDefineBase<Type, TBuilderId>
    {
        public override Type GetFactoryId(IFactoryProvider provider, IFactoryCollection<Type> collection)
        {
            return typeof(TFactory);
        }
    }
}