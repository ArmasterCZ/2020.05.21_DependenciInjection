using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection.Worker
{
    class MsSql
    {
        public EventHandler<string> LogInfo;

        public EventHandler<string> LogError;

        //private ILogger logger;

        public MsSql(string connectionString)
        {

        }

        public void ConnectToDb()
        {

        }

        public void CreateNewPc()
        {

        }

        public void CreateNewRecord()
        {

        }
    }
}
