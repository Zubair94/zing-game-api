using System;
using System.IO;
using System.Linq;

namespace ZingGameApi.Configurations
{
    public static class EnvironmentConfiguration
    {
        private static string _dbConnectionString = "";

        private static void BuildDbConnectionString(string key, string value) {
            string[] keys = {"Host", "Database", "Username", "Password"};
            if(keys.Any(key.Contains))
            {
                _dbConnectionString = key == "Password" ? string.Concat(_dbConnectionString, key, "=", value) 
                    : string.Concat(_dbConnectionString, key, "=", value, ";");
            }
        }

        public static void LoadEnvironment(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"environment file not found in {filePath}");
                }
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var environmentVariableArray = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    if (environmentVariableArray.Length != 2)
                        continue;

                    Environment.SetEnvironmentVariable(environmentVariableArray[0], environmentVariableArray[1]);
                    BuildDbConnectionString(environmentVariableArray[0], environmentVariableArray[1]);
                }
            } 
            catch(FileNotFoundException e) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(e);
                Console.ResetColor();
            }
        }

        public static string GetDbConnectionString()
        {
            return _dbConnectionString;
        }
    }
    
}