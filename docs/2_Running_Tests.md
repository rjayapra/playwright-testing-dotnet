# Running and Debugging Tests with Playwright for .NET

This guide provides an overview of how to run and debug tests using Playwright for .NET.

## Running Tests

To run your tests, use the `dotnet test` command. This will execute all the tests in your project.

```sh
dotnet test
```

### Running a Specific Test

To run a specific test, use the `--filter` option followed by the fully qualified name of the test.

```sh
dotnet test --filter FullyQualifiedName~Namespace.ClassName.MethodName
```

### Running Tests in Parallel

Playwright can run tests in parallel to speed up the execution. You can configure the degree of parallelism using the `--parallel` option.

```sh
dotnet test --parallel 4
```

## Debugging Tests

### Using Visual Studio

1. Open your project in Visual Studio.
2. Set breakpoints in your test code.
3. Right-click on the test method you want to debug and select `Debug Test(s)`.

### Using Visual Studio Code

1. Open your project in Visual Studio Code.
2. Set breakpoints in your test code.
3. Open the Debug panel and select `.NET Core Attach` configuration.
4. Start debugging.

### Using Command Line

You can also debug tests using the command line with the `--filter` option and attaching a debugger.

```sh
dotnet test --filter FullyQualifiedName~Namespace.ClassName.MethodName --no-build
```

Then attach your debugger to the test process.

## Additional Resources

- [Playwright .NET Documentation](https://playwright.dev/dotnet/docs/intro)
- [Playwright GitHub Repository](https://github.com/microsoft/playwright-dotnet)

For more detailed information, refer to the official Playwright documentation.
