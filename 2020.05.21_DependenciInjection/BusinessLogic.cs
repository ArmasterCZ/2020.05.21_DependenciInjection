using _2020._05._21_DependenciInjection.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    /*
    class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic()
        {

        }

        public void Run()
        {
            //create model
            User user = new User() { Identificator = Guid.NewGuid(), Name = "John Stark", Age = 31 };
            XmlWorker xmlWorker = new XmlWorker();

            //serialize
            string xml = xmlWorker.CreateXmlString(user);
            //Console.WriteLine(xml);

            //deserialize
            User user2 = xmlWorker.LoadFromXmlString<User>(xml);
            Console.WriteLine(user2.Name);

            Console.ReadLine();
        }

    }
    */

    /**/
    class BusinessLogic : IBusinessLogic
    {
        //private IUser user;

        //private IXmlWorker xmlWorker;

        //public BusinessLogic(IUser user, IXmlWorker xmlWorker)
        //{
        //    this.user = user;
        //    this.xmlWorker = xmlWorker;
        //}

        private readonly IContainer container;

        public BusinessLogic(IContainer container)
        {
            this.container = container;
        }

        public void Run()
        {
            //create model
            IUser user = container.Resolve<IUser>(); // new IUser() { Identificator = Guid.NewGuid(), Name = "John Stark", Age = 31 };
            user.Identificator = Guid.NewGuid();
            user.Name = "John Stark";
            user.Age = 31;

            var xmlWorker = container.Resolve<IXmlWorkerGen<IUser>>();

            //serialize
            string xml = xmlWorker.CreateXmlString(user);
            Console.WriteLine(xml);

            //var item = container.Resolve<IUser>().GetType();
            //Type type = typeof(IUser); // user.GetType();

            //deserialize
            IUser user2 = xmlWorker.LoadFromXmlString(xml);
            Console.WriteLine(user2.Name);

            Console.ReadLine();
        }

        public void RunGen()
        {


            Console.ReadLine();
        }

    }
    /**/
}
