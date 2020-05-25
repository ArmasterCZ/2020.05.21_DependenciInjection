namespace _2020._05._21_DependenciInjection.Interfaces
{
    public interface IOracle
    {
        void ConnectToDb();
        void CheckAccess();
        void CreateNewPc();
        void CreateNewRecord();
        string GetPcDescription();
    }
}