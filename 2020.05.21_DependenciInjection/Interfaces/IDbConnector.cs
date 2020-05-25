namespace _2020._05._21_DependenciInjection.Interfaces
{
    interface IDbConnector
    {
        void ConnectToDb();

        void CreateNewPc();
        void CreateNewRecord();
    }
}