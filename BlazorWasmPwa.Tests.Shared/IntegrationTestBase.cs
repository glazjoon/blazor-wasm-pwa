namespace BlazorWasmPwa.Tests.Shared;

public abstract class IntegrationTestBase<TProgram> where TProgram : class
{
    protected string? Environment = null;
    protected TestWebApplicationFactory<TProgram> Factory;
    protected HttpClient HttpClient { get; private set; }

    protected void SetUp()
    {
        Factory = new(Environment);
        HttpClient = Factory.CreateClient();
    }

    protected void TearDown()
    {
        Factory.Dispose();
        HttpClient.Dispose();
    }
}