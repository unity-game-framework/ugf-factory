using NUnit.Framework;
using UGF.Builder.Runtime.GameObjects;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactoryDefineBase
    {
        private class FactoryDefine : FactoryDefineBase<int, int>
        {
            public override int GetFactoryId(IFactoryProvider provider, IFactoryCollection<int> collection)
            {
                return 0;
            }

            public override void RegisterBuilders(IFactoryProvider provider, IFactoryCollection<int> collection, IFactory<int> factory)
            {
                factory[0] = new GameObjectBuilderEmpty();
            }
        }

        [Test]
        public void FactoryIdentifierType()
        {
            var define = new FactoryDefine();
            
            Assert.AreEqual(typeof(int), define.FactoryIdentifierType);
        }

        [Test]
        public void BuilderIdentifierType()
        {
            var define = new FactoryDefine();
            
            Assert.AreEqual(typeof(int), define.BuilderIdentifierType);
        }

        [Test]
        public void GetFactoryId()
        {
            var define = new FactoryDefine();
            
            Assert.AreEqual(0, define.GetFactoryId(null, null));
        }

        [Test]
        public void RegisterBuilders()
        {
            var define = new FactoryDefine();
            var factory = new Factory<int>();
            
            define.RegisterBuilders(null, null, factory);

            var builder = factory.Get<IGameObjectBuilder>(0);
            
            Assert.AreEqual(1, factory.Count);
            Assert.NotNull(builder);
        }

        [Test]
        public void GetCollection()
        {
            var define = new FactoryDefine();
            var provider = new FactoryProvider();

            IFactoryCollection<int> collection = define.GetCollection(provider);
            
            Assert.AreEqual(1, provider.Count);
            Assert.True(provider.Contains(typeof(int)));
            Assert.NotNull(collection);
        }

        [Test]
        public void GetFactory()
        {
            var define = new FactoryDefine();
            var provider = new FactoryProvider();
            var collection = new FactoryCollection<int>();

            IFactory<int> factory = define.GetFactory(provider, collection);
            
            Assert.AreEqual(1, collection.Count);
            Assert.True(collection.Contains(0));
            Assert.NotNull(factory);
        }

        [Test]
        public void CreateCollection()
        {
            var define = new FactoryDefine();

            IFactoryCollection<int> collection = define.CreateCollection(null);
            
            Assert.NotNull(collection);
            Assert.IsAssignableFrom(typeof(FactoryCollection<int>), collection);
        }

        [Test]
        public void CreateFactory()
        {
            var define = new FactoryDefine();

            IFactory<int> factory = define.CreateFactory(null, null);
            
            Assert.NotNull(factory);
            Assert.IsAssignableFrom(typeof(Factory<int>), factory);
        }
    }
}