using NLog;
using NLog.Config;
using StringConverter;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;

namespace LoggingConsoleApp
{
    internal class Program
    {
        private static IServiceProvider BuildDi(LoggingConfiguration config)
        {
            return new ServiceCollection()
                .AddTransient<IntegerParser>()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog(config);
                })
                .BuildServiceProvider();
        }

        static void InvokeParseInteger(IntegerParser parser, string stringNum)
        {
            try
            {
                Console.WriteLine(string.Format("{0} as string", stringNum));
                Console.WriteLine(parser.ParseInteger(stringNum));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null string!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Wrong format of string!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Null or empty input!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Integer overflow!");
            }
            catch (Exception)
            {
                Console.WriteLine("Unhandled exception!");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                LogManager.LoadConfiguration("nlog.config");
                var serviceProvider = BuildDi(LogManager.Configuration);

                using (serviceProvider as IDisposable)
                {
                    IntegerParser parser = serviceProvider.GetRequiredService<IntegerParser>();

                    InvokeParseInteger(parser, "12345");
                    InvokeParseInteger(parser, "asjdhgyhjk");
                    InvokeParseInteger(parser, "1235hjk");
                    InvokeParseInteger(parser, null);
                    InvokeParseInteger(parser, "1111111111111111111111111111111111111111111111111111111111111111111");
                    InvokeParseInteger(parser, "-12369252");
                    InvokeParseInteger(parser, "11-11-1111-11");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
