using Microsoft.Extensions.DependencyInjection;

namespace TestsPantry.DependecnyInjectionTests;

[MicrosoftDependencyInjectionDataSource]
public class MyTestClass2(
    IServiceProvider sp,      // scoped provider for THIS test run
    SomeClass1 singleton,
    SomeClass2 scoped,
    SomeClass3 transient)
{
    private const string DiLifetime = "DiLifetime";

    // These are the “static fields written by Test1”
    private static Guid _singletonId;
    private static Guid _scopedId;
    private static Guid _transientId;
    private static bool _captured;

    [Before(Class)]
    public static Task Reset()
    {
        _singletonId = default;
        _scopedId = default;
        _transientId = default;
        _captured = false;
        return Task.CompletedTask;
    }

    [Test]
    [NotInParallel(DiLifetime, Order = 1)]
    public async Task Test1_capture_ids_and_prove_within_scope_rules()
    {
        // capture constructor-injected instances
        _singletonId = singleton.Id;
        _scopedId = scoped.Id;
        _transientId = transient.Id;
        _captured = true;

        // Prove lifetimes *within the same scope*:
        var scopedAgain = sp.GetRequiredService<SomeClass2>();
        var transientAgain = sp.GetRequiredService<SomeClass3>();

        // Scoped: same instance within same scope
        await Assert.That(scopedAgain).IsSameReferenceAs(scoped);          // reference equality :contentReference[oaicite:3]{index=3}
        await Assert.That(scopedAgain.Id).IsEqualTo(scoped.Id);

        // Transient: new instance each resolve
        await Assert.That(transientAgain).IsNotSameReferenceAs(transient); // reference equality :contentReference[oaicite:4]{index=4}
        await Assert.That(transientAgain.Id).IsNotEqualTo(transient.Id);
    }

    [Test]
    [NotInParallel(DiLifetime, Order = 2)]
    public async Task Test2_compare_constructor_instances_to_Test1_snapshot()
    {
        await Assert.That(_captured).IsTrue(); // makes it obvious if you ran Test2 alone

        // Singleton: same across tests (because RootProvider is static/shared)
        await Assert.That(singleton.Id).IsEqualTo(_singletonId);

        // New test == new scope (your data source does CreateScope per test),
        // so Scoped and Transient should be different from Test1:
        await Assert.That(scoped.Id).IsNotEqualTo(_scopedId);
        await Assert.That(transient.Id).IsNotEqualTo(_transientId);
    }
}