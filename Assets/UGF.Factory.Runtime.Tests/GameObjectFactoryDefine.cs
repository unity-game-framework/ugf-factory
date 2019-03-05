using System;
using UGF.Builder.Runtime.GameObjects;
using UnityEngine;
using UnityEngine.Scripting;

namespace UGF.Factory.Runtime.Tests
{
    [FactoryDefine, Preserve]
    public class GameObjectFactoryDefine : FactoryDefine<IGameObjectBuilder, string>
    {
        public override void RegisterBuilders(IFactoryProvider provider, IFactoryCollection<Type> collection, IFactory<string> factory)
        {
            factory["prefab"] = new GameObjectBuilder(new GameObject("prefab"));
            factory["empty"] = new GameObjectBuilderEmpty();
        }
    }
}