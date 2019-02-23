using UnityEngine;

namespace UGF.Factory.Runtime.Builders
{
    public class FactoryBuilderObject<TResult> : IFactoryBuilder<TResult> where TResult : Object
    {
        public TResult Source { get; }

        public FactoryBuilderObject(TResult source)
        {
            Source = source;
        }

        public TResult Build()
        {
            return Object.Instantiate(Source);
        }
    }
}