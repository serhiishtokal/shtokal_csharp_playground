namespace TestsPantry.TestExamples;

public class TimeSpanTests
{
    [Test]
    public async Task FromSeconds_WithNonInteger_WorksCorrectly()
    {
        const double seconds = 0.1;
        var timeSpan = TimeSpan.FromSeconds(seconds);

        await Assert.That(timeSpan.TotalSeconds).IsEqualTo(0.1);
        await Assert.That(timeSpan.Milliseconds).IsEqualTo(100);
        await Assert.That(timeSpan.Seconds).IsEqualTo(0);
    }
}
