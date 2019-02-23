using System;
using UnityEngine;

namespace UGF.Factory.Runtime.Builders
{
    public class FactoryBuilderComponent<TComponent> : IFactoryBuilderComponent<TComponent> where TComponent : Component
    {
        public Type Type { get; }

        public FactoryBuilderComponent(Type type)
        {
            Type = type;
        }

        public TComponent Build(GameObject gameObject)
        {
            return (TComponent)gameObject.AddComponent(Type);
        }
    }
}