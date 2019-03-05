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

            FactoryUtility.RegisterFactories(provider);

            GameObject gameObject1 = provider.GetBuilder<IGameObjectBuilder, string>("prefab").Build();
            GameObject gameObject2 = provider.GetBuilder<IGameObjectBuilder, string>("empty").Build();
            
            Assert.NotNull(gameObject1);
            Assert.NotNull(gameObject2);
            Assert.AreEqual("prefab(Clone)", gameObject1.name);
            Assert.AreEqual("New Game Object", gameObject2.name);
        }
    }
}