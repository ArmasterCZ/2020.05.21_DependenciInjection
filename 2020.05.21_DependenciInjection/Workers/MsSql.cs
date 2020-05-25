using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    internal class MsSql : IMsSql, IDbConnector
    {
        ILogger logger;

        private string connectionString;

        public MsSql(string connectionString, ILogger logger)
        {
            this.connectionString = connectionString;
        }

        public void ConnectToDb()
        {

        }

        public void CreateNewPc()
        {
            Console.WriteLine("Creating new PC in MsSql");
        }

        public void CreateNewRecord()
        {
            Console.WriteLine("Creating new Record in MsSql");
        }

        public void FormatConnectionString()
        {
            Console.WriteLine("Formating connection string {0}",connectionString);
        }
    }
}
