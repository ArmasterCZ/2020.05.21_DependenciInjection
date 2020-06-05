using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    class DeepStructureLv2 : IDeepStructureLv2
    {
        ILogger logger;

        IDeepStructureLv3 deepStructureLv3;

        public DeepStructureLv2(ILogger logger, IDeepStructureLv3 deepStructureLv3)
        {
            this.logger = logger;
            this.deepStructureLv3 = deepStructureLv3;
        }

        public void CallMeMayby()
        {
            Console.WriteLine($"You call {this}");
            deepStructureLv3.CallMeMayby();
        }

        public string GetSomeString()
        {
            return "This is string you allways wanted! Go with it.";
        }
    }
}
