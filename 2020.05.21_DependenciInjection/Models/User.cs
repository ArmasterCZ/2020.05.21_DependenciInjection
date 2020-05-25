using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    public class User : IUser
    {
        public Guid Identificator { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

    }
}
