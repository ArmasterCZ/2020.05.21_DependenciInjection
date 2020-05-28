using System.Collections.Generic;

namespace _2020._05._21_DependenciInjection.Interfaces
{
    internal interface IOracle : IDbConnector
    {
        void ConnectToDb();
        void CheckAccess();
        bool CreateNewPc();
        void CreateNewRecord();
        string GetPcDescription();
        List<PcDto> GetListOfPcs();
    }
}