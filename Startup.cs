using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Snoopy.Function.Startup))]
namespace Snoopy.Function {
  public class Startup : FunctionsStartup {
    public override void Configure(IFunctionsHostBuilder builder) {
      var connStr = Environment.GetEnvironmentVariable("CSTRING");
      builder.Services.AddDbContext<SchoolDbContext>(
        option => option.UseSqlServer(connStr));

      builder.Services.AddHttpClient();
    }
  }
}