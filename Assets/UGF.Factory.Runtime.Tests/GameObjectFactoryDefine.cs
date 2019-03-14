using System;
using UGF.Builder.Runtime.GameObjects;
using UnityEngine;

namespace UGF.Factory.Runtime.Tests
{
    [FactoryDefine]
    public class GameObjectFactoryDefine : FactoryDefine<IGameObjectBuilder, string>
    {
        public override void RegisterBuilders(IFactoryProvider provider, IFactoryCollection<Type> collection, IFactory<string> factory)
        {
            factory["prefab"] = new GameObjectBuilder(new GameObject("prefab"));
            factory["empty"] = new GameObjectBuilderEmpty();
        }
    }
}