using System;
using NUnit.Framework;
using UGF.Builder.Runtime.GameObjects;
using UnityEngine;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactoryProviderExtensions
    {
        [Test]
        public void GetBuilder()
        {
            var provider = new FactoryProvider();
            var collection = new FactoryCollection<Type>();
            var factory = new Factory<string>();
            
            factory.Add("empty", new GameObjectBuilderEmpty());
            factory.Add("prefab", new GameObjectBuilder(new GameObject("prefab")));
            collection.Add(typeof(IGameObjectBuilder), factory);
            provider.Add(typeof(Type), collection);

            IGameObjectBuilder builder1 = provider.GetBuilder<IGameObjectBuilder, string>("empty");
            IGameObjectBuilder builder2 = provider.GetBuilder<IGameObjectBuilder, string>("prefab");
            
            Assert.NotNull(builder1);
            Assert.NotNull(builder2);
        }

        [Test]
        public void GetBuilder2()
        {
            var provider = new FactoryProvider();
            var collection = new FactoryCollection<Type>();
            var factory = new Factory<string>();
            
            factory.Add("empty", new GameObjectBuilderEmpty());
            factory.Add("prefab", new GameObjectBuilder(new GameObject("prefab")));
            collection.Add(typeof(IGameObjectBuilder), factory);
            provider.Add(typeof(Type), collection);

            IGameObjectBuilder builder1 = provider.GetBuilder<IGameObjectBuilder, Type, string>(typeof(IGameObjectBuilder), "empty");
            IGameObjectBuilder builder2 = provider.GetBuilder<IGameObjectBuilder, Type, string>(typeof(IGameObjectBuilder), "prefab");
            
            Assert.NotNull(builder1);
            Assert.NotNull(builder2);
        }
    }
}