using NUnit.Framework;
using UGF.Builder.Runtime.GameObjects;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactoryProvider
    {
        [Test]
        public void Count()
        {
            var provider = new FactoryProvider<int>();
            
            provider.Add(0, new Factory<int>());
            
            Assert.AreEqual(1, provider.Count);
        }

        [Test]
        public void This()
        {
        }

        [Test]
        public void Test()
        {
            var provider = new FactoryProvider<int>();
            var factory = new Factory<int>();
            
            provider.Add(0, factory);
            factory.Add(0, new GameObjectBuilderEmpty());

            var gameObject1 = provider.Get<IFactory<int>>(0).Get<IGameObjectBuilder>(0).Build("Test");
            var gameObject2 = provider.Get<int, IGameObjectBuilder>(0, 0).Build("Test");
            
            Assert.NotNull(gameObject1);
            Assert.NotNull(gameObject2);
            Assert.AreEqual(gameObject1.name, gameObject2.name);
        }
    }
}