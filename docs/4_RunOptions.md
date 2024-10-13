## Running Options with .NET Playwright

This document provides an overview of the various running options available when using Playwright with .NET.

## Prerequisites

- .NET SDK installed
- Playwright installed (`dotnet add package Microsoft.Playwright`)


## Running Specific Tests

To run a specific test, use the `--filter` option:

```pwsh
dotnet test --filter "FullyQualifiedName~Namespace.ClassName.MethodName"
```
Run the ContextOptionsTest using the filter options

```
dotnet test --filter TestWithCustomContextOptions
```

## Running Tests in Headless Mode

By default, Playwright runs in headless mode. To run tests in headed mode, set the `Headless` property to `false` in your test setup. You can also use `SlowMo` to slow down execution.

```csharp
var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
```

or from the powershell command line set the environment variable **$env:HEADED:"1"** 

```
$env:HEADED="1"
dotnet test --filter TestWithCustomContextOptions
```

## Running Tests with Different Browsers

Playwright supports multiple browsers. You can specify the browser in your test setup:

```csharp
var browser = await playwright.Firefox.LaunchAsync();
```

From command line;

```
dotnet test -- Playwright.BrowserName=webkit
```

To run your test on multiple browsers or configurations, you need to invoke the dotnet test command multiple times. Either specify the BROWSER environment variable or set the Playwright.BrowserName via the runsettings file:

```
dotnet test --settings:chromium.runsettings
dotnet test --settings:firefox.runsettings
dotnet test --settings:webkit.runsettings
```
Sample chromium.runsettings file
```
<?xml version="1.0" encoding="utf-8"?>
  <RunSettings>
    <Playwright>
      <BrowserName>chromium</BrowserName>
    </Playwright>
  </RunSettings>
```
Supported browsers include: Chromium, Firefox, WebKit


## Running Tests in Parallel

To run tests in parallel with multiple workers, use the parallel option:

For MSTest
```
dotnet test -- MSTest.Parallelize.Workers=5
```

For Nunit
```
dotnet test -- MSTest.Parallelize.Workers=5
```

## Debug options:
Playwright comes with the Playwright Inspector which allows you to step through Playwright API calls, see their debug logs and explore locators.

```
$env:PWDEBUG=1
dotnet test
```
## RunSettings

Using .runsettings file. When running tests from Visual Studio, you can take advantage of the .runsettings file. The following shows a reference of the supported values.

For example, to specify the number of workers, you can use MSTest.Parallelize.Workers. You can also enable DEBUG logs using RunConfiguration.EnvironmentVariables.

```
<RunSettings>
  <!-- MSTest adapter -->  
  <MSTest>
    <Parallelize>
      <Workers>4</Workers>
      <Scope>ClassLevel</Scope>
    </Parallelize>
  </MSTest>
  <!-- General run configuration -->
  <RunConfiguration>
    <EnvironmentVariables>
      <!-- For debugging selectors, it's recommend to set the following environment variable -->
      <DEBUG>pw:api</DEBUG>
    </EnvironmentVariables>
  </RunConfiguration>
  <!-- Playwright -->  
  <Playwright>
    <BrowserName>chromium</BrowserName>
    <ExpectTimeout>5000</ExpectTimeout>
    <LaunchOptions>
      <Headless>false</Headless>
      <Channel>msedge</Channel>
    </LaunchOptions>
  </Playwright>
</RunSettings>
```
## References

For more advanced configurations, refer to the [Playwright .NET documentation](https://playwright.dev/dotnet/docs/intro).
For selective testing options refer to [Selective Unit Tests](https://learn.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests?pivots=mstest).

