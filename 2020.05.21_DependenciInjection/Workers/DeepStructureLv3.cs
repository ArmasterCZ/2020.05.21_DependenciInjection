using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    class DeepStructureLv3 : IDeepStructureLv3
    {
        ILogger logger;

        IDeepStructureLvMulti deepStructureLvMulti;

        public DeepStructureLv3(ILogger logger, IDeepStructureLvMulti deepStructureLvMulti)
        {
            this.logger = logger;
            this.deepStructureLvMulti = deepStructureLvMulti;
            logger.LogInfo("Log from Lv3");
        }

        public void CallMeMayby()
        {
            Console.WriteLine($"You call {this}");
            for (int i = 0; i < 3; i++)
            {
                deepStructureLvMulti.CallMeMayby();
            }
        }

        public string GetSomeString()
        {
            return "Too deep men.. to deep...";
        }
    }
}
