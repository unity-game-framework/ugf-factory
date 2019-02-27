using System;
using NUnit.Framework;
using UGF.Builder.Runtime.GameObjects;
using UnityEngine;

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
        public void Test1()
        {
            var provider = new FactoryProvider<int>();
            var factory = new Factory<int>();
            
            provider.Add(0, factory);
            factory.Add(0, new GameObjectBuilderEmpty());

            var gameObject1 = provider.Get<IFactory<int>>(0).Get<IGameObjectBuilder>(0).Build("Test");
            var gameObject2 = provider.GetBuilder<IGameObjectBuilder, int, int>(0, 0).Build("Test");
            var gameObject3 = provider.GetBuilder(0, 0).Build(null);
            
            Assert.NotNull(gameObject1);
            Assert.NotNull(gameObject2);
            Assert.NotNull(gameObject3);
        }
    }
}