using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    class DeepStructureLvMultiFactory
    {
        private readonly ILogger logger;

        //TODO not used
        private IDeepStructureLvMulti deepStructureLvMulti { get; }

        public DeepStructureLvMultiFactory(IDeepStructureLvMulti deepStructureLvMulti, ILogger logger)
        {
            this.deepStructureLvMulti = deepStructureLvMulti;
            this.logger = logger;
        }


        public IDeepStructureLvMulti GetNewDeepStructure()
        {
            return new DeepStructureLvMulti(logger);
        }
    }
}
