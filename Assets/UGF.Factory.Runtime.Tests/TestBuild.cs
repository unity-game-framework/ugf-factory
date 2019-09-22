using System;
using NUnit.Framework;
using UGF.Builder.Runtime.GameObjects;
using UnityEngine;

namespace UGF.Factory.Runtime.Tests
{
    public class TestBuild
    {
        [Test]
        public void BuildGameObject()
        {
            var provider = new FactoryProvider();
            var collection = new FactoryCollection<Type>();
            var factory = new Factory<string>();

            provider.Add(collection);
            collection.Add(typeof(IGameObjectBuilder), factory);
            factory.Add("prefab", new GameObjectBuilder(new GameObject("prefab")));
            factory.Add("empty", new GameObjectBuilderEmpty());

            GameObject gameObject1 = provider.GetBuilder<IGameObjectBuilder, string>("prefab").Build();
            GameObject gameObject2 = provider.GetBuilder<IGameObjectBuilder, string>("empty").Build();

            Assert.NotNull(gameObject1);
            Assert.NotNull(gameObject2);
            Assert.AreEqual("prefab(Clone)", gameObject1.name);
            Assert.AreEqual("New Game Object", gameObject2.name);
        }
    }
}
