using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    internal class MsSql : IMsSql
    {
        ILogger logger;

        public string ConnectionString { get; set; }

        public MsSql(string connectionString, ILogger logger)
        {
            this.ConnectionString = connectionString;
            this.logger = logger;
            logger.LogInfo($"Created instance of IMsSql with conn string ({ConnectionString})");
        }

        public void ConnectToDb()
        {
            logger.LogInfo($"Query - Access checked {ConnectionString}");
        }

        public bool CreateNewPc()
        {
            logger.LogInfo("Query - Creating new PC in MsSql");
            return true;
        }

        public void CreateNewRecord()
        {
            logger.LogInfo("Query - Creating new Record in MsSql");
        }

        public List<PcDto> GetListOfPcs()
        {
            logger.LogInfo("Query - getting list of PC");
            //logger.LogError("Query - getting list of PC");
            return new List<PcDto>() { 
                new PcDto() { Id = 1, Name = "PC1234", Description = "Pc of somebody ot there" },
                new PcDto() { Id = 2, Name = "jvPc", Description = "Read this carefully" },
                new PcDto() { Id = 3, Name = "NomadForever", Description = "Join our discord server. Pleeease." }
            };
        }

        public void FormatConnectionString()
        {
            logger.LogInfo(string.Format("Formating connection string {0}", ConnectionString));
        }
    }
}
