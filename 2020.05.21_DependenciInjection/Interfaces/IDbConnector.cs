using System.Collections.Generic;

namespace _2020._05._21_DependenciInjection.Interfaces
{
    internal interface IDbConnector
    {
        void ConnectToDb();

        bool CreateNewPc();
        void CreateNewRecord();
        List<PcDto> GetListOfPcs();
    }
}