using System;
using System.Collections.Generic;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    public class FactoryProvider : IFactoryProvider
    {
        private readonly Dictionary<Type, IFactoryCollection> m_collections = new Dictionary<Type, IFactoryCollection>();

        public IBuilder GetBuilder<TFactoryId, TBuilderId>(TFactoryId factoryId, TBuilderId builderId)
        {
            var collection = (FactoryCollection<TFactoryId>)m_collections[typeof(TFactoryId)];
            var factory = (Factory<TBuilderId>)collection[factoryId];

            return factory[builderId];
        }
    }
}