using NUnit.Framework;
using UGF.Builder.Runtime;
using UGF.Builder.Runtime.GameObjects;
using UnityEngine;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactory
    {
        [Test]
        public void Count()
        {
            var factory = new Factory<int>
            {
                { 0, new GameObjectBuilderEmpty() }
            };

            Assert.AreEqual(1, factory.Count);
        }

        [Test]
        public void This()
        {
            var factory = new Factory<int>
            {
                { 0, new GameObjectBuilderEmpty() }
            };

            var builder = factory[0];

            factory[0] = new GameObjectBuilderEmpty();
        }

        [Test]
        public void Contains()
        {
            var factory = new Factory<int>
            {
                { 0, new GameObjectBuilderEmpty() }
            };
            
            Assert.True(factory.Contains(0));
        }

        [Test]
        public void Add()
        {
            var factory = new Factory<int>();

            factory.Add(0, new GameObjectBuilderEmpty());
            
            Assert.AreEqual(1, factory.Count);
        }

        [Test]
        public void Remove()
        {
            var factory = new Factory<int>();
            
            factory.Add(0, new GameObjectBuilderEmpty());
            factory.Remove(0);
            
            Assert.AreEqual(0, factory.Count);
            Assert.IsFalse(factory.Contains(0));
        }

        [Test]
        public void Clear()
        {
            var factory = new Factory<int>();
            
            factory.Add(0, new GameObjectBuilderEmpty());
            factory.Clear();
            
            Assert.AreEqual(0, factory.Count);
        }

        [Test]
        public void Get()
        {
            var factory = new Factory<int>();
            
            factory.Add(0, new GameObjectBuilderEmpty());

            var builder = factory.Get<GameObjectBuilderEmpty>(0);
            
            Assert.NotNull(builder);
        }

        [Test]
        public void TryGetGeneric()
        {
            var factory = new Factory<int>();
            
            factory.Add(0, new GameObjectBuilderEmpty());

            bool result1 = factory.TryGet<GameObjectBuilderEmpty>(0, out var builder1);
            bool result2 = factory.TryGet<IBuilder<string>>(0, out var builder2);
            bool result3 = factory.TryGet<IGameObjectBuilder>(0, out var builder3);
            
            Assert.True(result1);
            Assert.NotNull(builder1);
            Assert.False(result2);
            Assert.Null(builder2);
            Assert.True(result3);
            Assert.NotNull(builder3);
        }

        [Test]
        public void TryGet()
        {
            var factory = new Factory<int>();
            
            factory.Add(0, new GameObjectBuilderEmpty());

            bool result1 = factory.TryGet(0, out var builder1);
            bool result2 = factory.TryGet(1, out var builder2);
            
            Assert.True(result1);
            Assert.NotNull(builder1);
            Assert.False(result2);
            Assert.Null(builder2);
        }

        [Test]
        public void GetIdentifierType()
        {
            var factory = new Factory<int>();
            
            Assert.NotNull(factory.GetIdentifierType());
            Assert.True(factory.GetIdentifierType() == typeof(int));
        }

        [Test]
        public void GetEnumerator()
        {
            var factory = new Factory<int>();

            foreach (var pair in factory)
            {
            }
        }
    }
}