using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    public class Oracle : IOracle, IDbConnector
    {
        public EventHandler<string> LogInfo;

        public EventHandler<string> LogError;

        public Oracle(string connectionString)
        {

        }

        public void CheckAccess()
        {
            Console.WriteLine("Access checked");
        }

        public void ConnectToDb()
        {
            Console.WriteLine("DB connected in Oracle");
        }

        public void CreateNewPc()
        {
            Console.WriteLine("Creating new PC in Oracle");
        }

        public void CreateNewRecord()
        {
            Console.WriteLine("Creating new Record in Oracle");
        }

        public string GetPcDescription()
        {
            return "PC Win 10 OOracle";
        }
    }
}
