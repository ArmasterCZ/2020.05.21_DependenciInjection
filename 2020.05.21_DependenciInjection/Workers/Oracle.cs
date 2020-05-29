using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    internal class Oracle : IOracle
    {
        private ILogger logger;

        public string ConnectionString { get; set; }

        public Oracle(string connectionString, ILogger logger)
        {
            this.ConnectionString = connectionString;
            this.logger = logger;
            logger.LogInfo($"Created instance of Oracle with conn string ({ConnectionString})");
        }

        public void CheckAccess()
        {
            logger.LogInfo($"Query - Access checked");
        }

        public void ConnectToDb()
        {
            logger.LogInfo($"Query - DB connected in Oracle {ConnectionString}");
        }

        public bool CreateNewPc()
        {
            logger.LogInfo("Query - Creating new PC in Oracle");
            return true;
        }

        public void CreateNewRecord()
        {
            File.WriteAllText("Record.txt", "Byl zapsán record.");
            //logger.LogInfo("Query - Creating new Record in Oracle");
        }

        public string GetPcDescription()
        {
            return "PC Win 10 Oracle";
        }

        public List<PcDto> GetListOfPcs()
        {
            logger.LogInfo("Query - getting list of PC");

            return new List<PcDto>() {
                new PcDto() { Id = 1, Name = "PC1234", Description = "Pc of somebody ot there" },
                new PcDto() { Id = 2, Name = "jvPc", Description = "Read this carefully" },
                new PcDto() { Id = 3, Name = "NomadForever", Description = "Join our discord server. Pleeease." }
            };
        }
    }
}
