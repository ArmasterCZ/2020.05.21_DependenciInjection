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
        private int usageCount = 0;

        public string pathToLog { get; set; }

        public Logger2()
        {

        }

        public void LogError(string message)
        {
            usageCount ++;
            Console.WriteLine($"Lg2 error ({message}) {usageCount}");
        }

        public void LogInfo(string message)
        {
            usageCount++;
            Console.WriteLine($"Lg2 ({message}) {usageCount}");
        }
    }
}
