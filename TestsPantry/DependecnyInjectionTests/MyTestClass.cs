using Microsoft.Extensions.DependencyInjection;

namespace TestsPantry.DependecnyInjectionTests;

[MicrosoftDependencyInjectionDataSource]
public class MyTestClass(
    IServiceProvider provider,          // scoped provider for this test's scope
    IServiceScopeFactory scopeFactory,  // lets us create a second scope inside the same test
    SomeClass1 singletonFromCtor,
    SomeClass2 scopedFromCtor,
    SomeClass3 transientFromCtor)
{
    [Test]
    public async Task Singleton_is_same_in_same_and_other_scopes()
    {
        var singletonAgain = provider.GetRequiredService<SomeClass1>();
        await Assert.That(singletonAgain).IsSameReferenceAs(singletonFromCtor);

        using var otherScope = scopeFactory.CreateScope();
        var singletonOtherScope = otherScope.ServiceProvider.GetRequiredService<SomeClass1>();
        await Assert.That(singletonOtherScope).IsSameReferenceAs(singletonFromCtor);
    }

    [Test]
    public async Task Scoped_is_same_within_scope_but_changes_in_new_scope()
    {
        var scopedAgain = provider.GetRequiredService<SomeClass2>();
        await Assert.That(scopedAgain).IsSameReferenceAs(scopedFromCtor);

        using var otherScope = scopeFactory.CreateScope();
        var scopedOtherScope = otherScope.ServiceProvider.GetRequiredService<SomeClass2>();
        await Assert.That(scopedOtherScope).IsNotSameReferenceAs(scopedFromCtor);
    }

    [Test]
    public async Task Transient_is_new_every_time()
    {
        var t1 = provider.GetRequiredService<SomeClass3>();
        var t2 = provider.GetRequiredService<SomeClass3>();

        await Assert.That(t1).IsNotSameReferenceAs(transientFromCtor);
        await Assert.That(t2).IsNotSameReferenceAs(t1);
    }
}