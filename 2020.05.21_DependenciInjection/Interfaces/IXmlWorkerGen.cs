namespace _2020._05._21_DependenciInjection
{
    internal interface IXmlWorkerGen<T>
    {
        string CreateXmlString(object data);
        string FormatXmlString(string xmlText);
        T LoadFromXmlString(string xmlText);
        object LoadFromXmlString(string xmlText, object obj);
        void LoadFromXmlString(string xmlText, ref object output);
        T LoadXmlFile(string path);
        void SaveXmlFile(string path, object data);
    }
}