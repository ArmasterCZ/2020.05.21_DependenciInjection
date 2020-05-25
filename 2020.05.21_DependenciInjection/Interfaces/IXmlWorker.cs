namespace _2020._05._21_DependenciInjection.Interfaces
{
    internal interface IXmlWorker
    {
        string CreateXmlString(object data);
        string FormatXmlString(string xmlText);
        T LoadFromXmlString<T>(string xmlText);
        T LoadXmlFile<T>(string path);
        void SaveXmlFile(string path, object data);
    }
}