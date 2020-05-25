using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    internal class Config : IConfig
    {
        public string ConnectionString { get; set; }

        public int TimerTime { get; set; }

        public string UserName { get; set; }

        public string UserPass { get; set; }
    }
}
