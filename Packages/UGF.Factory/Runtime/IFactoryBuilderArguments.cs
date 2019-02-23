namespace UGF.Factory.Runtime
{
    public interface IFactoryBuilderArguments : IFactoryBuilder
    {
        object Build(object[] arguments = null);
    }
}