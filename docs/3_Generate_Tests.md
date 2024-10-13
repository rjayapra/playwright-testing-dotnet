# Playwright Codegen for .NET

Playwright is a powerful tool for browser automation and end-to-end testing. One of its standout features is the ability to generate test scripts automatically. This document provides an introduction to using Playwright's code generation capabilities in .NET.

## Introduction

Playwright's code generation feature allows you to record your interactions with a web application and generate corresponding test scripts in .NET. This can significantly speed up the process of writing tests and ensure accuracy.

## Prerequisites

Before you begin, ensure you have the following installed:
- .NET SDK
- Node.js
- Playwright CLI

## Installation

To install Playwright for .NET, run the following command in your terminal:

```bash
dotnet add package Microsoft.Playwright
```

## Generating Tests

1. **Start Codegen**: Use the codegen command to run the test generator followed by the URL of the website you want to generate tests for:

    ```pwsh
    pwsh bin/Debug/net8.0/playwright.ps1 codegen demo.playwright.dev/todomvc
    ```
The URL is optional and you can always run the command without it and then add the URL directly into the browser window instead.

Or if you have setup vscode extension for playwright go to "Testing" -> "Record New"" under Playwright

![alt text](image.png)

2. **Interact with the Application**: A browser window will open. Interact with your web application as you normally would. Playwright will record these interactions.
    1. Add items to todo list
    1. Complete to-do list
    1. Check if remaining items in list match the values

3. **Save the Script**: Once you have completed your interactions, Playwright will display the generated script. Copy this script to a test file.

## Example

Here is an example of a generated test script in .NET:

```
using Microsoft.Playwright.MSTest;
using Microsoft.Playwright;

[TestClass]
public class Tests : PageTest
{
    [TestMethod]
    public async Task MyTest()
    {
        await Page.GotoAsync("https://demo.playwright.dev/todomvc/#/");
        await Page.GetByPlaceholder("What needs to be done?").ClickAsync();
        await Page.GetByPlaceholder("What needs to be done?").FillAsync("Task 2");
        await Page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");
        await Page.GetByPlaceholder("What needs to be done?").FillAsync("Task 2");
        await Page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");
        await Page.Locator("li").Filter(new() { HasText = "Task 1" }).GetByLabel("Toggle Todo").CheckAsync();
        await Expect(Page.Locator("body")).ToContainTextAsync("Task 2");
    }
}
```

For more detailed information, visit the [official documentation](https://playwright.dev/dotnet/docs/codegen-intro).
