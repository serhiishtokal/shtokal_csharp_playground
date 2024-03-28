namespace AspNetPlayground.Helpers;

public class DecoratorChainBuilder<TInstance> where TInstance : class
{
    private readonly IServiceProvider _sp;
    private TInstance Current { get; set; }

    private DecoratorChainBuilder(IServiceProvider sp, TInstance baseInstance)
    {
        _sp = sp;
        Current = baseInstance;
    }

    public static DecoratorChainBuilder<TInstance> Create<TDecorated>(IServiceProvider sp) where TDecorated : TInstance
    {
        var baseInstance = ActivatorUtilities.CreateInstance<TDecorated>(sp);
        return new DecoratorChainBuilder<TInstance>(sp, baseInstance);
    }

    public DecoratorChainBuilder<TInstance> DecorateWith<TDecorator>() where TDecorator : TInstance
    {
        var decoratedInstance = ActivatorUtilities.CreateInstance<TDecorator>(_sp, Current);
        Current = decoratedInstance;
        return this;
    }

    public TInstance Build()
    {
        return Current;
    }
}