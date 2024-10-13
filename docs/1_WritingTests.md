## Introduction

Playwright tests are simple, they

* perform actions, and
* assert the state against expectations.

Playwright automatically waits for the wide range of actionability checks to pass prior to performing each action.

## Actions
Refer the [WritingTests.cs](./PlaywrightTests/WritingTests.cs) file


### Navigations
Most of the tests will start by navigating the page to a URL. After that, the test will be able to interact with the page elements.

```
await Page.GotoAsync("https://playwright.dev");
```

Playwright will wait for the page to reach the load state prior to moving forward. Learn more about the Page.GotoAsync() options.

### Interactions

Performing actions starts with locating the elements. Playwright uses Locators API for that.

```dotnet
// Create a locator.
var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

// Click it.
await getStarted.ClickAsync();
```
or in one line

```
await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();
```


### Basic Actions

| Action                    | Description                       |
|---------------------------|-----------------------------------|
| `Locator.CheckAsync()`    | Check the input checkbox          |
| `Locator.ClickAsync()`    | Click the element                 |
| `Locator.UncheckAsync()`  | Uncheck the input checkbox        |
| `Locator.HoverAsync()`    | Hover mouse over the element      |
| `Locator.FillAsync()`     | Fill the form field, input text   |
| `Locator.FocusAsync()`    | Focus the element                 |
| `Locator.PressAsync()`    | Press single key                  |
| `Locator.SetInputFilesAsync()` | Pick files to upload        |
| `Locator.SelectOptionAsync()`  | Select option in the drop down |


## Assertions

Playwright provides an async function called Expect to assert and wait until the expected condition is met.

```
await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
```

| Assertion                          | Description                          |
|------------------------------------|--------------------------------------|
| `Expect(Locator).ToBeCheckedAsync()` | Checkbox is checked                  |
| `Expect(Locator).ToBeEnabledAsync()` | Control is enabled                   |
| `Expect(Locator).ToBeVisibleAsync()` | Element is visible                   |
| `Expect(Locator).ToContainTextAsync()` | Element contains text               |
| `Expect(Locator).ToHaveAttributeAsync()` | Element has attribute              |
| `Expect(Locator).ToHaveCountAsync()` | List of elements has given length    |
| `Expect(Locator).ToHaveTextAsync()` | Element matches text                 |
| `Expect(Locator).ToHaveValueAsync()` | Input element has value              |
| `Expect(Page).ToHaveTitleAsync()` | Page has title                        |
| `Expect(Page).ToHaveURLAsync()` | Page has URL                           |

## Test Isolation

The Playwright NUnit and MSTest test framework base classes will isolate each test from each other by providing a separate Page instance. Pages are isolated between tests due to the Browser Context, which is equivalent to a brand new browser profile, where every test gets a fresh environment, even when multiple tests run in a single Browser.

For MSTest;
```
dotnet new mstest -n PlaywrightTests
cd PlaywrightTests
dotnet add package Microsoft.Playwright.MSTest
```

For Nunit
```
dotnet new nunit -n PlaywrightTests
cd PlaywrightTests
dotnet add package Microsoft.Playwright.NUnit
```

## Build the project
Build the project so the playwright.ps1 is available inside the bin directory.

```
dotnet build
```
Now you can install required browsers.  If you are using a different version of .NET you will need to adjust the command and change net8.0 to your version.  

```
pwsh bin/Debug/net8.0/playwright.ps1 install

```
**Note** : Install powershell if not available

Example test would like below; Refer [WritingTests.cs](./PlaywrightTests/WritingTests.cs)

```dotnetcli
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlaywrightTests;

[TestClass]
public class ExampleTest : PageTest
{
    [TestMethod]
    public async Task HasTitle()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [TestMethod]
    public async Task GetStartedLink()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Click the get started link.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    } 
}
```

### Run the test
```
dotnet test
```

### Using Hooks

You can use SetUp/TearDown in NUnit or TestInitialize/TestCleanup in MSTest to prepare and clean up your test environment. Refer [WritingTestwithHooks.cs](./PlaywrightTests/WritingTestwithHooks.cs)

For example to load the baseurl;
```
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("https://playwright.dev");
    }

```

