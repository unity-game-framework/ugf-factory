namespace UGF.Factory.Runtime
{
    public interface IFactoryBuilder<out TResult> : IFactoryBuilder
    {
        TResult Build();
    }
}