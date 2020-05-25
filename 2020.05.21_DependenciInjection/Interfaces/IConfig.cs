namespace _2020._05._21_DependenciInjection.Interfaces
{
    interface IConfig
    {
        string ConnectionString { get; set; }
        int TimerTime { get; set; }
        string UserName { get; set; }
        string UserPass { get; set; }
    }
}