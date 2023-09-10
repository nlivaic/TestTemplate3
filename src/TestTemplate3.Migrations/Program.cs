using System;
using System.IO;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestTemplate3.Migrations
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var connectionString = string.Empty;
            var dbUser = string.Empty;
            var dbPassword = string.Empty;
            var scriptsPath = string.Empty;

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Development";
            Console.WriteLine($"Environment: {env}.");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            InitializeParameters();
            var connectionStringTestTemplate3 = new SqlConnectionStringBuilder(connectionString)
            {
                UserID = dbUser,
                Password = dbPassword
            }.ConnectionString;

            var upgraderTestTemplate3 =
                DeployChanges.To
                    .SqlDatabase(connectionStringTestTemplate3)
                    .WithScriptsFromFileSystem(
                        !string.IsNullOrWhiteSpace(scriptsPath)
                                ? Path.Combine(scriptsPath, "TestTemplate3Scripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate3Scripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate3.");
            var resultTestTemplate3 = upgraderTestTemplate3.PerformUpgrade();

            if (!resultTestTemplate3.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate3 upgrade error: {resultTestTemplate3.Error}");
                Console.ResetColor();
                return -1;
            }

            // Uncomment the below sections if you also have an Identity Server project in the solution.
            /*
            var connectionStringTestTemplate3Identity = string.IsNullOrWhiteSpace(args.FirstOrDefault())
                ? config["ConnectionStrings:TestTemplate3IdentityDb"]
                : args.FirstOrDefault();

            var upgraderTestTemplate3Identity =
                DeployChanges.To
                    .SqlDatabase(connectionStringTestTemplate3Identity)
                    .WithScriptsFromFileSystem(
                        scriptsPath != null
                            ? Path.Combine(scriptsPath, "TestTemplate3IdentityScripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate3IdentityScripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate3 Identity.");
            if (env != "Development")
            {
                upgraderTestTemplate3Identity.MarkAsExecuted("0004_InitialData.sql");
                Console.WriteLine($"Skipping 0004_InitialData.sql since we are not in Development environment.");
                upgraderTestTemplate3Identity.MarkAsExecuted("0005_Initial_Configuration_Data.sql");
                Console.WriteLine($"Skipping 0005_Initial_Configuration_Data.sql since we are not in Development environment.");
            }
            var resultTestTemplate3Identity = upgraderTestTemplate3Identity.PerformUpgrade();

            if (!resultTestTemplate3Identity.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate3 Identity upgrade error: {resultTestTemplate3Identity.Error}");
                Console.ResetColor();
                return -1;
            }
            */

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;

            void InitializeParameters()
            {
                if (args.Length == 0)
                {
                    connectionString = config["ConnectionStrings:TestTemplate3Db_Migrations_Connection"];
                    dbUser = config["DB_USER"];
                    dbPassword = config["DB_PASSWORD"];
                }
                else if (args.Length == 4)
                {
                    connectionString = args[0];
                    dbUser = args[1];
                    dbPassword = args[2];
                    scriptsPath = args[3];
                }
            }
        }
    }
}
