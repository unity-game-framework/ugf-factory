using UnityEngine;

namespace UGF.Factory.Runtime.Builders
{
    public class FactoryBuilderGameObject : FactoryBuilderObject<GameObject>, IFactoryBuilderGameObject
    {
        public FactoryBuilderGameObject(GameObject source) : base(source)
        {
        }

        public GameObject Build(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return parent != null ? Object.Instantiate(Source, position, rotation, parent) : Object.Instantiate(Source, position, rotation);
        }
    }
}