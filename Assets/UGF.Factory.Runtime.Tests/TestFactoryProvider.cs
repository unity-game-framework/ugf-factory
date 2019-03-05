using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactoryProvider
    {
        [Test]
        public void Count()
        {
            var provider = new FactoryProvider();
            
            provider.Add(new FactoryCollection<int>());
            
            Assert.AreEqual(1, provider.Count);
        }

        [Test]
        public void ContainsKey()
        {
            var provider = new FactoryProvider();
            
            provider.Add(new FactoryCollection<int>());

            bool result = provider.Contains(typeof(int));
            
            Assert.True(result);
        }

        [Test]
        public void ContainsValue()
        {
            var provider = new FactoryProvider();
            var collection = new FactoryCollection<int>();
            
            provider.Add(collection);

            bool result = provider.Contains(collection);
            
            Assert.True(result);
        }

        [Test]
        public void Add()
        {
            var provider = new FactoryProvider();
            
            provider.Add(new FactoryCollection<int>());
            
            Assert.AreEqual(1, provider.Count);
        }

        [Test]
        public void Remove()
        {
            var provider = new FactoryProvider();
            var collection = new FactoryCollection<int>();
            
            provider.Add(collection);
            provider.Remove(collection);
            
            Assert.AreEqual(0, provider.Count);
        }

        [Test]
        public void Clear()
        {
            var provider = new FactoryProvider();
            
            provider.Add(new FactoryCollection<int>());
            provider.Clear();
            
            Assert.AreEqual(0, provider.Count);
        }

        [Test]
        public void GetGeneric()
        {
            var provider = new FactoryProvider();
            
            provider.Add(new FactoryCollection<int>());

            IFactoryCollection<int> collection = provider.Get<int>();
            
            Assert.NotNull(collection);
        }

        [Test]
        public void TryGetGeneric()
        {
            var provider = new FactoryProvider();
            
            provider.Add(new FactoryCollection<int>());

            bool result1 = provider.TryGet(out IFactoryCollection<int> collection1);
            bool result2 = provider.TryGet(out IFactoryCollection<long> collection2);
            
            Assert.True(result1);
            Assert.False(result2);
            Assert.NotNull(collection1);
            Assert.Null(collection2);
        }

        [Test]
        public void TryGet()
        {
            var provider = new FactoryProvider();
            
            provider.Add(new FactoryCollection<int>());

            bool result1 = provider.TryGet(typeof(int), out IFactoryCollection collection1);
            bool result2 = provider.TryGet(typeof(long), out IFactoryCollection collection2);
            
            Assert.True(result1);
            Assert.False(result2);
            Assert.NotNull(collection1);
            Assert.Null(collection2);
        }

        [Test]
        public void CopyTo()
        {
            var provider = new FactoryProvider();
            var array = new KeyValuePair<Type, IFactoryCollection>[1];
            
            provider.Add(new FactoryCollection<int>());
            provider.CopyTo(array, 0);

            KeyValuePair<Type, IFactoryCollection> pair = array[0];
            
            Assert.AreEqual(typeof(int), pair.Key);
            Assert.NotNull(pair.Value);
        }
    }
}