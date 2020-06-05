using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    interface IUserFactory
    {
        IUser GetUser();
    }

    class UserFactory : IUserFactory
    {
        public IUser GetUser()
        {
            if (ConfigurationManager.AppSettings["User1"] == null)
            {
                return new User();
            }
            else
            {
                return new User();
            }
        }

    }
}

