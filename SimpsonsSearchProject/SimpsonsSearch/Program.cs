using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SimpsonsSearch
{
	public class Program
	{

        private readonly ILogger<Program> logger;

        public Program()
        {
            var services = new ServiceCollection()
                .AddLogging(logBuilder => logBuilder.SetMinimumLevel(LogLevel.Debug))
                .BuildServiceProvider();


            logger = services.GetService<Microsoft.Extensions.Logging.ILoggerFactory>()
                .AddLog4Net()
                .CreateLogger<Program>();
        }

        public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();

            
        }

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
