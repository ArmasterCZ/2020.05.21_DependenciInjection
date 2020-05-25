using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    internal class ConfigLoader : IConfigLoader
    {
        private readonly string path;

        public ConfigLoader(string path)
        {
            this.path = path;
        }

        public IConfig GetConfig()
        {
            return new Config() { ConnectionString = $"something {path}" };
        }
    }
}
