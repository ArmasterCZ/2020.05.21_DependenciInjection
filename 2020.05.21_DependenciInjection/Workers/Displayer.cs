using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    class Displayer : IDisplayer
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

    }
}
