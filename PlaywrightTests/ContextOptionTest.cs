using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests.BasicTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ContextOptionTest : PageTest
{
    [Test]
    public async Task TestWithCustomContextOptions()
    {
        
        await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50
        });

        await using var context = await browser.NewContextAsync(ContextOptions());
   
        // The following Page (and BrowserContext) instance has the custom colorScheme, viewport and baseURL set:
        await Page.GotoAsync("/login");
        await Page.ScreenshotAsync(new()
{
             Path = "screenshot.png"
        });
    }

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
        {
            ColorScheme = ColorScheme.Light,
            ViewportSize = new()
            {
                Width = 1920,
                Height = 1080
            },
            BaseURL = "https://github.com",
            
        };
    }
}