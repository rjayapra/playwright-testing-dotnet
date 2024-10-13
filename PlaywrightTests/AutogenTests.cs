using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
namespace PlaywrightTests.BasicTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class AutoGenTest : PageTest
{
    [Test]
    public async Task CodeGenTest()
    {
        await Page.GotoAsync("https://playwright.dev/");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();
        await Expect(Page.Locator("h1")).ToContainTextAsync("Installation");
        await Page.GetByLabel("Search").ClickAsync();
        await Page.GetByPlaceholder("Search docs").FillAsync("Installation");
        await Page.GetByPlaceholder("Search docs").PressAsync("Enter");
        await Expect(Page.Locator("h1")).ToContainTextAsync("Installation");
    }
}
