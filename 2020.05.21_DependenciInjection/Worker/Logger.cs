using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection.Worker
{
    class Logger : ILogger
    {
        public string pathToLog { get; set; }

        public Logger(string path)
        {

        }

        public void LogError(string message)
        {
            Console.WriteLine($"Writing error log {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Writing info log {message}");
        }
    }
}
