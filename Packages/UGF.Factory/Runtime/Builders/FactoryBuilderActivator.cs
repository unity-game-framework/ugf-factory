using System;

namespace UGF.Factory.Runtime.Builders
{
    public class FactoryBuilderActivator : IFactoryBuilderArguments
    {
        public Type Type { get; }

        public FactoryBuilderActivator(Type type)
        {
            Type = type;
        }

        public object Build(object[] arguments = null)
        {
            return arguments != null && arguments.Length > 0 ? Activator.CreateInstance(Type, arguments) : Activator.CreateInstance(Type);
        }
    }
}