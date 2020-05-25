using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    internal class Logger2 : ILogger
    {
        public string pathToLog { get; set; }

        public Logger2()
        {

        }

        public void LogError(string message)
        {
            Console.WriteLine($"Writing error log {message} logger2");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Writing info log {message} logger2");
        }
    }
}
