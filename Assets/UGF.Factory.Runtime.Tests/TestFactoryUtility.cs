using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UGF.Assemblies.Runtime;
using UGF.Builder.Runtime.GameObjects;

namespace UGF.Factory.Runtime.Tests
{
    public class TestFactoryUtility
    {
        private class FactoryDefine : FactoryDefine<IGameObjectBuilder, string>
        {
            public override void RegisterBuilders(IFactoryProvider provider, IFactoryCollection<Type> collection, IFactory<string> factory)
            {
            }
        }
        
        [Test]
        public void RegisterFactories()
        {
            var provider = new FactoryProvider();
            
            FactoryUtility.RegisterFactories(provider);
            
            Assert.GreaterOrEqual(provider.Count, 1);
        }

        [Test]
        public void GetFactoryDefinesAll()
        {
            var defines = new List<IFactoryDefine>();
            
            FactoryUtility.GetFactoryDefines(defines);
            
            Assert.GreaterOrEqual(defines.Count, 1);
        }

        [Test]
        public void GetFactoryDefinesFromAssembly()
        {
            var defines = new List<IFactoryDefine>();
            Assembly assembly = typeof(TestFactoryUtility).Assembly;
            
            FactoryUtility.GetFactoryDefines(defines, assembly);
            
            Assert.GreaterOrEqual(defines.Count, 1);
        }

        [Test]
        public void GetFactoryDefinesFromTypes()
        {
            var defines = new List<IFactoryDefine>();
            var types = new List<Type>();
            
            AssemblyUtility.GetBrowsableTypes<FactoryDefineAttribute>(types);
            
            FactoryUtility.GetFactoryDefines(defines, types);
            
            Assert.GreaterOrEqual(defines.Count, 1);
        }

        [Test]
        public void TryCreateFactoryDefine()
        {
            Type type = typeof(FactoryDefine);
            bool result = FactoryUtility.TryCreateFactoryDefine(type, out IFactoryDefine define);
            
            Assert.True(result);
            Assert.NotNull(define);
            Assert.IsAssignableFrom(typeof(FactoryDefine), define);
        }
    }
}