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
        private string path;

        public ConfigLoader()
        {
            
        }

        public IConfig GetConfig(string path)
        {
            this.path = path;
            return new Config() { ConnectionString = $"ConStringFrom-{this.path}", TimerTime = 10 , UserName = "Am", UserPass = "ShallNotPass" };
        }
    }
}
