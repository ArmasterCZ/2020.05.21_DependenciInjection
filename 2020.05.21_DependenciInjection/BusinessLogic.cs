using _2020._05._21_DependenciInjection.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
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
            //RunXmlExample();
            //RunDbExample();
            RunDeepExample();
        }

        public void RunXmlExample()
        {
            //create model
            IUser user = container.Resolve<IUser>(); // new IUser() { Identificator = Guid.NewGuid(), Name = "John Stark", Age = 31 };
            user.Identificator = Guid.NewGuid();
            user.Name = "John Stark";
            user.Age = 31;

            var xmlWorker = container.Resolve<IXmlWorkerGen<IUser>>();
            //var xmlWorker = container.Resolve<IXmlWorkerGen<IUser>>(new TypedParameter(user.GetType(), user)); // still IUser no User

            //serialize
            string xml = xmlWorker.CreateXmlString(user);
            Console.WriteLine(xml);

            //deserialize (for known type)
            var xmlWorker2 = container.Resolve<IXmlWorkerGen<User>>();
            IUser user2 = xmlWorker2.LoadFromXmlString(xml);
            Console.WriteLine($"Deserilizes known user identition: {user2.Identificator}");

            //deserialize (for interface IUser)
            IUser user3 = container.Resolve<IUser>();
            object obj = xmlWorker.LoadFromXmlString(xml, user3);
            Type type = user3.GetType();
            dynamic dynamicUser = Convert.ChangeType(obj, type);
            Console.WriteLine($"Deserilizes dynamic user name: {dynamicUser.Name}");

            Console.ReadLine();
        }

        public void RunDbExample()
        {
            ILogger logger = container.Resolve<ILogger>();

            //load config
            IConfigLoader loader = container.Resolve<IConfigLoader>();
            IConfig config = loader.GetConfig("C:\\\\setting.xml");
            config.ConnectionString = "This IS connectuion string.";
            logger.LogInfo($"{config.ConnectionString.ToString()}");
            
            //get PC for both DB
            IDbConnector connectorMsSql = container.Resolve<IMsSql>(new NamedParameter("connectionString", config.ConnectionString));
            connectorMsSql.CreateNewPc();
            IDbConnector connectorOracle = container.Resolve<IOracle>(new NamedParameter("connectionString", config.ConnectionString));
            connectorOracle.CreateNewPc();

            //create PC for one DB
            IDbConnector connectorDbRandom;
            if ((new Random()).Next(0, 2) == 0)
            {
                //parameter is used only when not specified in container
                connectorDbRandom = container.Resolve<IMsSql>(new NamedParameter("connectionString", config.ConnectionString));
            }
            else
            {
                connectorDbRandom = container.Resolve<IOracle>(new NamedParameter("connectionString", config.ConnectionString));
            }
            connectorDbRandom.ConnectToDb();
            connectorDbRandom.CreateNewPc();

            Console.ReadLine();
        }

        public void RunDeepExample()
        {
            IDeepStructureLv1 deepStructureLv1 = container.Resolve<IDeepStructureLv1>();
            deepStructureLv1.CallMeMayby();

            Console.ReadLine();
        }
    }
}
