using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    internal class Logger : ILogger
    {
        public string pathToLog { get; set; }

        public Logger()
        {

        }

        public void LogError(string message)
        {
            Console.WriteLine($"Lg Error ({message})");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Lg ({message})");
        }
    }
}
