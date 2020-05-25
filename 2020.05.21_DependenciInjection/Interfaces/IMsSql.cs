namespace _2020._05._21_DependenciInjection.Interfaces
{
    interface IMsSql
    {
        void ConnectToDb();
        void FormatConnectionString();
        void CreateNewPc();
        void CreateNewRecord();
    }
}