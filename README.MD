# Playwright C# with NUnit and GitHub Actions

This project demonstrates the use of Playwright with NUnit to automate browser testing, integrated with GitHub Actions for continuous integration (CI). The GitHub Actions pipeline is configured to use GitHub Secrets for securely handling credentials required during the test run.

## Prerequisites
```bash
dotnet add package Microsoft.Playwright
dotnet restore
dotnet tool install --global Microsoft.Playwright.CLI
playwright install

# RUN TESTS
dotnet test

GitHub Secrets
- 
SAUCEDEMO_USERNAME: {{ secrets.SAUCE_USERNAME }}
SAUCEDEMO_PASSWORD: {{ secrets.SAUCE_PASSWORD }}

# Secrets placed inside GitHub Secrets - and are checked during run in GitHub Actions.