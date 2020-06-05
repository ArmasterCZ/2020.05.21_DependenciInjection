using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    class UserCreator
    {
        //IList<Shareholding> _holdings = new List<Shareholding>();
        private IUserFactory userFactory;

        public UserCreator(IUserFactory userFactory)
        {
            this.userFactory = userFactory;
        }

        public List<IUser> GetUsers()
        {
            List<IUser> users = new List<IUser>();

            IUser user = userFactory.GetUser();
            users.Add(user);
            users.Add(user);
            users.Add(user);
            return users;
        }
    }
}
