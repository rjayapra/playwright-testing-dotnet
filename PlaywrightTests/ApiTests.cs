using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests.API;
public class APITests
{
    private IPlaywright _playwright;
    private IBrowser _browser;

    [SetUp]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
    }

    [TearDown]
    public async Task Teardown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    [Test]
    public async Task TestApiResponse()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

            Assert.IsTrue(responseBody.Contains("\"id\": 1"));
        }
    }

    [Test]
    public async Task TestApiPostResponse()
    {
        using (var client = new HttpClient())
        {
        var getResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
        getResponse.EnsureSuccessStatusCode();
        Console.WriteLine(await getResponse.Content.ReadAsStringAsync());

        // Example POST request
        var postData = new StringContent(
            Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                title = "foo",
                body = "bar",
                userId = 1
            }), 
            System.Text.Encoding.UTF8, 
            "application/json");

        var postResponse = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", postData);
        postResponse.EnsureSuccessStatusCode();
        Console.WriteLine(await postResponse.Content.ReadAsStringAsync());
        }
    }
}
