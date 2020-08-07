using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LastFMScore.Services;

namespace LastFMScore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["LastFmApi:Endpoint"]) });
            builder.Services.AddSingleton(sp => new LastFMService(sp.GetService<HttpClient>(), builder.Configuration["LastFmApi:ApiKey"]));
            builder.Services.AddSingleton(sp => new ScoreService(sp.GetService<LastFMService>()));

            await builder.Build().RunAsync();
        }
    }
}
