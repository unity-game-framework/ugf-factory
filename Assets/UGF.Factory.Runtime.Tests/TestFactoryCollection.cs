using System.Collections.Generic;
using NUnit.Framework;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactoryCollection
    {
        [Test]
        public void Count()
        {
            var collection = new FactoryCollection<int>();
            
            collection.Add(0, null);
            
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void IdentifierType()
        {
            var collection = new FactoryCollection<int>();
            
            Assert.AreEqual(typeof(int), collection.IdentifierType);
        }

        [Test]
        public void ContainsKey()
        {
            var collection = new FactoryCollection<int>();
            
            collection.Add(0, null);

            bool result = collection.Contains(0);
            
            Assert.True(result);
        }

        [Test]
        public void ContainsValue()
        {
            var collection = new FactoryCollection<int>();
            var factory = new Factory<int>();
            
            collection.Add(0, factory);

            bool result = collection.Contains(factory);
            
            Assert.True(result);
        }

        [Test]
        public void Add()
        {
            var collection = new FactoryCollection<int>();
            
            collection.Add(0, null);
            
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void Remove()
        {
            var collection = new FactoryCollection<int>();
            
            collection.Add(0, null);
            collection.Remove(0);
            
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void Clear()
        {
            var collection = new FactoryCollection<int>();
            
            collection.Add(0, null);
            collection.Clear();
            
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void GetGeneric()
        {
            var collection = new FactoryCollection<int>();
            
            collection.Add(0, new Factory<int>());

            var factory = collection.Get<Factory<int>>(0);
            
            Assert.NotNull(factory);
        }

        [Test]
        public void TryGetGeneric()
        {
            var collection = new FactoryCollection<int>();
            
            collection.Add(0, new Factory<int>());

            bool result1 = collection.TryGet(0, out Factory<int> factory1);
            bool result2 = collection.TryGet(1, out Factory<int> factory2);
            
            Assert.True(result1);
            Assert.False(result2);
            Assert.NotNull(factory1);
            Assert.Null(factory2);
        }

        [Test]
        public void TryGet()
        {
            var collection = new FactoryCollection<int>();
            
            collection.Add(0, new Factory<int>());

            bool result1 = collection.TryGet(0, out IFactory factory1);
            bool result2 = collection.TryGet(1, out IFactory factory2);
            
            Assert.True(result1);
            Assert.False(result2);
            Assert.NotNull(factory1);
            Assert.Null(factory2);
        }

        [Test]
        public void CopyTo()
        {
            var collection = new FactoryCollection<int>();
            var array = new KeyValuePair<int, IFactory>[1];
            
            collection.Add(1, new Factory<int>());
            collection.CopyTo(array, 0);

            KeyValuePair<int, IFactory> pair = array[0];
            
            Assert.AreEqual(1, pair.Key);
            Assert.NotNull(pair.Value);
        }
    }
}