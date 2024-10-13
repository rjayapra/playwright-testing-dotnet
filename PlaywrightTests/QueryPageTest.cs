using App.Tests.Models;
using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests.UI;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class QueryPageTest : PageTest
{
    [Test]
    public async Task QueryPage()
    {
        var page = new SearchPage(Page);
        await page.GotoAsync();
        await page.SearchAsync("search query");
    }
}