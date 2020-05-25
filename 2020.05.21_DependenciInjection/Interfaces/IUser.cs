using System;

namespace _2020._05._21_DependenciInjection.Interfaces
{
    public interface IUser
    {
        int Age { get; set; }
        Guid Identificator { get; set; }
        string Name { get; set; }
    }
}