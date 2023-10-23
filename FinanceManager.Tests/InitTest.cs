using FinanceManager.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Tests;
public class InitTest : IClassFixture<IntegrationTestFactory<Program, ApplicationDbContext>>
{
    private readonly string serverUrl;
    private IntegrationTestFactory<Program, ApplicationDbContext> _factory;
    public InitTest(IntegrationTestFactory<Program, ApplicationDbContext> factory) 
    {
        _factory = factory;
        serverUrl = _factory.ServerAddress;
        
    }   

    [Fact]
    public async Task Navigate_to_counter_ensure_current_counter_increases_on_click()
    {
        var playwright = await Playwright.CreateAsync();

        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 50 });

        var page = await browser.NewPageAsync();

        await page.GotoAsync(serverUrl);

        var result =  page.GetByRole(role: AriaRole.Heading);

        
    }
}
