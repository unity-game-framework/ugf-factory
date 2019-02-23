using System;

namespace UGF.Factory.Runtime.Builders
{
    public class FactoryBuilderDelegate : IFactoryBuilderArguments
    {
        public Delegate Delegate { get; }

        public FactoryBuilderDelegate(Delegate @delegate)
        {
            Delegate = @delegate;
        }

        public object Build(object[] arguments = null)
        {
            return Delegate.DynamicInvoke(arguments);
        }
    }
}