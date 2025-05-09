﻿using ExamenFinalApp.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddBlazorBootstrap();

builder.RootComponents.Add<App>("#app"); 

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();