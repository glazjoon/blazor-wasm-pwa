using NUnit.Framework;

namespace BlazorWasmPwa.Tests.Shared;

public abstract class IntegrationTest : IntegrationTestBase<Program>
{
    [SetUp]
    protected new void SetUp() =>  base.SetUp();

    [TearDown]
    public new void TearDown() => base.TearDown();
}