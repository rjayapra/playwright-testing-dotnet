# Setting Up Continuous Integration for .NET Playwright Testing in Azure DevOps

This guide will help you set up continuous integration (CI) for your .NET Playwright tests using Azure DevOps.

## Prerequisites

- Azure DevOps account
- .NET SDK installed
- Playwright installed in your .NET project

## Steps

### Create a New Pipeline

1. Navigate to your Azure DevOps project.
2. Go to **Pipelines** > **New Pipeline**.
3. Select your repository source (e.g., Azure Repos Git, GitHub, etc.).
4. Choose **YAML** and select the repository where your code is located.
5. Choose existing pipeline and select PlaywrightTests/azdo/playwright-pipeline.yml

### Monitor the Pipeline

Go to the **Pipelines** section in Azure DevOps to monitor the progress of your pipeline. You should see the pipeline running and executing your .NET Playwright tests.

## Conclusion

You have successfully set up continuous integration for your .NET Playwright tests in Azure DevOps. Your tests will now run automatically on each push to the `master` branch.
