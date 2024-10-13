## Playwright - Page Object Models

Large test suites can be structured to optimize ease of authoring and maintenance. Page object models are one such approach to structure your test suite.


### Implementation

Page object models wrap over a Playwright Page.

```csharp
    using System.Threading.Tasks;
    using Microsoft.Playwright;
    
    namespace App.Tests.Models;
    
    public class SearchPage
    {
      private readonly IPage _page;
      private readonly ILocator _searchTermInput;
    
      public SearchPage(IPage page)
      {
        _page = page;
        _searchTermInput = page.Locator("[aria-label='Enter your search term']");
      }
    
      public async Task GotoAsync()
      {
        await _page.GotoAsync("https://bing.com");
      }
    
      public async Task SearchAsync(string text)
      {
        await _searchTermInput.FillAsync(text);
        await _searchTermInput.PressAsync("Enter");
      }
    }
```

Build the test using the object model 

```csharp
    using App.Tests.Models;
    
    // in the test
    var page = new SearchPage(await browser.NewPageAsync());
    await page.GotoAsync();
    await page.SearchAsync("search query");
```
2. Refer the files [SearchPage.cs](./PlaywrightTests/pages/SearchPage.cs) and [QueryPageTest.cs](./PlaywrightTests/QueryPageTest.cs)
    ```

3. Run the test

```pwsh
dotnet test --filter QueryPageTest
```

## Additional Resources

- [Playwright .NET Documentation](https://playwright.dev/dotnet/docs/next/test-runners)
- [Page object model](https://playwright.dev/dotnet/docs/pom)