using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    class DeepStructureLvMulti : IDeepStructureLvMulti
    {
        ILogger logger;

        int counter = 0;

        public DeepStructureLvMulti(ILogger logger)
        {
            this.logger = logger;
        }

        public void CallMeMayby()
        {
            counter++;
            Console.WriteLine($"You call {this} count = {counter}");
        }

        public string GetSomeString()
        {
            return "Too deep men.. to deep...";
        }
    }
}
