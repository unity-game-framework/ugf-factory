using UnityEngine;

namespace UGF.Factory.Runtime.Builders
{
    public interface IFactoryBuilderGameObject : IFactoryBuilder<GameObject>
    {
        GameObject Build(Vector3 position, Quaternion rotation, Transform parent = null);
    }
}