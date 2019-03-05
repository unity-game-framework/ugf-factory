using System;
using NUnit.Framework;
using UGF.Builder.Runtime.GameObjects;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactoryDefine
    {
        private class FactoryDefine : FactoryDefine<IGameObjectBuilder, int>
        {
            public override void RegisterBuilders(IFactoryProvider provider, IFactoryCollection<Type> collection, IFactory<int> factory)
            {
                factory[0] = new GameObjectBuilderEmpty();
            }
        }

        [Test]
        public void FactoryIdentifierType()
        {
            var define = new FactoryDefine();
            
            Assert.AreEqual(typeof(Type), define.FactoryIdentifierType);
        }
        
        [Test]
        public void GetFactoryId()
        {
            var define = new FactoryDefine();
            
            Assert.AreEqual(typeof(IGameObjectBuilder), define.GetFactoryId(null, null));
        }
    }
}