# Trace Viewer with Playwright for .NET using NUnit

Playwright's trace viewer allows you to capture and view the execution of your tests. Below is an example of how to use the trace viewer in a Playwright test with the NUnit framework in .NET.

## Recording a trace

1. Create a new test file `TraceTests.cs` and record traces using BrowserContext.Tracing API:

```csharp
namespace PlaywrightTests;

public class Tests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }

    [Test]
    public async Task GetStartedLink()
    {
        // ..
    }
}
```

This will record a zip file for each test, e.g. PlaywrightTests.ExampleTest.GetStartedLink.zip and place it into the bin/Debug/net8.0/playwright-traces/ directory.

## Running the Test

1. Run the test:
    ```
    dotnet test --filter TraceTests
    ```

2. After the test runs, a `.zip` file will be generated in the project directory.


3. View the traces with 
```
pwsh bin/Debug/net8.0/playwright.ps1 show-trace bin/Debug/net8.0/playwright-traces/PlaywrightTests.BasicTests.TraceTests.GetStarted.zip
```

This will open a browser window where you can view the detailed trace of your test execution.

### Reference

* [Trace Viewer](https://playwright.dev/dotnet/docs/next/trace-viewer-intro)