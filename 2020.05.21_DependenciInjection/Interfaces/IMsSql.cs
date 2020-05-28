using System.Collections.Generic;

namespace _2020._05._21_DependenciInjection.Interfaces
{
    interface IMsSql : IDbConnector
    {
        void ConnectToDb();
        void FormatConnectionString();
        bool CreateNewPc();
        void CreateNewRecord();
        List<PcDto> GetListOfPcs();
    }
}