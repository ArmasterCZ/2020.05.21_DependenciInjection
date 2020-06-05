using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    class DeepStructureLv1 : IDeepStructureLv1
    {
        ILogger logger;

        IDeepStructureLv2 deepStructureLv2;

        public DeepStructureLv1(ILogger logger, IDeepStructureLv2 deepStructureLv2)
        {
            this.logger = logger;
            this.deepStructureLv2 = deepStructureLv2;
        }

        public void CallMeMayby()
        {
            Console.WriteLine($"You call {this}");
            deepStructureLv2.CallMeMayby();
        }

        public string GetSomeString()
        {
            return "Something is Different.. But i cannot recall what exactly.";
        }
    }
}
