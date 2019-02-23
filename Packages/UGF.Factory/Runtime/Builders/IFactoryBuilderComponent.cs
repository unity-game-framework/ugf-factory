using UnityEngine;

namespace UGF.Factory.Runtime.Builders
{
    public interface IFactoryBuilderComponent<out TComponent> : IFactoryBuilder where TComponent : Component
    {
        TComponent Build(GameObject gameObject);
    }
}