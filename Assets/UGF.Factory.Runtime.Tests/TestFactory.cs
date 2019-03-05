using System.Collections.Generic;
using NUnit.Framework;
using UGF.Builder.Runtime;
using UGF.Builder.Runtime.GameObjects;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactory
    {
        [Test]
        public void Count()
        {
            var factory = new Factory<int>();

            factory.Add(0, null);

            Assert.AreEqual(1, factory.Count);
        }

        [Test]
        public void IdentifierType()
        {
            var factory = new Factory<int>();

            Assert.AreEqual(typeof(int), factory.IdentifierType);
        }

        [Test]
        public void ContainsKey()
        {
            var factory = new Factory<int>();

            factory.Add(0, new GameObjectBuilderEmpty());

            bool result = factory.Contains(0);

            Assert.True(result);
        }

        [Test]
        public void ContainsValue()
        {
            var factory = new Factory<int>();
            var builder = new GameObjectBuilderEmpty();

            factory.Add(0, builder);

            bool result = factory.Contains(builder);

            Assert.True(result);
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
        public void GetGeneric()
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

            bool result1 = factory.TryGet(0, out GameObjectBuilderEmpty builder1);
            bool result2 = factory.TryGet(1, out GameObjectBuilderEmpty builder2);

            Assert.True(result1);
            Assert.False(result2);
            Assert.NotNull(builder1);
            Assert.Null(builder2);
        }

        [Test]
        public void TryGet()
        {
            var factory = new Factory<int>();

            factory.Add(0, new GameObjectBuilderEmpty());

            bool result1 = factory.TryGet(0, out IBuilder builder1);
            bool result2 = factory.TryGet(1, out IBuilder builder2);

            Assert.True(result1);
            Assert.False(result2);
            Assert.NotNull(builder1);
            Assert.Null(builder2);
        }

        [Test]
        public void CopyTo()
        {
            var factory = new Factory<int>();
            var array = new KeyValuePair<int, IBuilder>[1];

            factory.Add(1, new GameObjectBuilderEmpty());
            factory.CopyTo(array, 0);

            KeyValuePair<int, IBuilder> pair = array[0];
            
            Assert.AreEqual(1, pair.Key);
            Assert.NotNull(pair.Value);
        }
    }
}