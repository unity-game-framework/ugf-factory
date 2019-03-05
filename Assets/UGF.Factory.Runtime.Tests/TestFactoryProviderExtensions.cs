using System;
using NUnit.Framework;
using UGF.Builder.Runtime;
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
            provider.Add(collection);

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
            provider.Add(collection);

            IGameObjectBuilder builder1 = provider.GetBuilder<IGameObjectBuilder, Type, string>(typeof(IGameObjectBuilder), "empty");
            IGameObjectBuilder builder2 = provider.GetBuilder<IGameObjectBuilder, Type, string>(typeof(IGameObjectBuilder), "prefab");

            Assert.NotNull(builder1);
            Assert.NotNull(builder2);
        }

        [Test]
        public void TryGetBuilder()
        {
            var provider = new FactoryProvider();
            var collection = new FactoryCollection<Type>();
            var factory = new Factory<string>();

            factory.Add("empty", new GameObjectBuilderEmpty());
            factory.Add("prefab", new GameObjectBuilder(new GameObject("prefab")));
            collection.Add(typeof(IGameObjectBuilder), factory);
            provider.Add(collection);

            bool result1 = provider.TryGetBuilder("empty", out IGameObjectBuilder builder1);
            bool result2 = provider.TryGetBuilder("prefab", out IGameObjectBuilder builder2);
            bool result3 = provider.TryGetBuilder("empty", out IBuilder builder3);
            bool result4 = provider.TryGetBuilder("prefab2", out IGameObjectBuilder builder4);
            
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.NotNull(builder1);
            Assert.NotNull(builder2);
            Assert.Null(builder3);
            Assert.Null(builder4);
        }

        [Test]
        public void TryGetBuilder2()
        {
            var provider = new FactoryProvider();
            var collection = new FactoryCollection<Type>();
            var factory = new Factory<string>();

            factory.Add("empty", new GameObjectBuilderEmpty());
            factory.Add("prefab", new GameObjectBuilder(new GameObject("prefab")));
            collection.Add(typeof(IGameObjectBuilder), factory);
            provider.Add(collection);

            bool result1 = provider.TryGetBuilder(typeof(IGameObjectBuilder), "empty", out IGameObjectBuilder builder1);
            bool result2 = provider.TryGetBuilder(typeof(IGameObjectBuilder), "prefab", out IGameObjectBuilder builder2);
            bool result3 = provider.TryGetBuilder(typeof(int), "empty", out IBuilder builder3);
            bool result4 = provider.TryGetBuilder(typeof(IGameObjectBuilder), "prefab2", out IGameObjectBuilder builder4);
            
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.NotNull(builder1);
            Assert.NotNull(builder2);
            Assert.Null(builder3);
            Assert.Null(builder4);
        }
    }
}