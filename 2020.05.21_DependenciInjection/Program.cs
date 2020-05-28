using _2020._05._21_DependenciInjection.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2020._05._21_DependenciInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //show what can get thrue reflection for container
            //DisplayAssemblyTypes();

            //map interfaces with classes
            IContainer container = MapContainer();

            //test that
            BusinessLogic businessLogic = new BusinessLogic(container);
            businessLogic.Run();
        }

            

        /// <summary>
        /// map interface with classes (automatic)
        /// </summary>
        /// <returns>Container with liked clasees</returns>
        internal static IContainer MapContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterType<User>().As<IUser>();
            builder.RegisterType<ConfigLoader>().As<IConfigLoader>();
            

            //unfunctional
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Interfaces") || t.Name.EndsWith("Models") || t.Name.EndsWith("Worker"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //can be better
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => !t.Name.Contains("Program")) //všechno krom Program.cs má interface == true
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //good?
            List<Type> typesAll = Assembly.GetExecutingAssembly().GetTypes().ToList();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.GetInterfaces().Length > 0 && typesAll.Where(all => all.Name.Equals("I" + t.Name)).Count() > 0).As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //generic nonfunctional
            builder.RegisterGeneric(typeof(XmlWorkerGen1<>)).As(typeof(IXmlWorkerGen<>)).InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(XmlWorkerGen1<User>)).As(typeof(IXmlWorkerGen<IUser>)).InstancePerLifetimeScope(); //nonfunctional

            //test 
            //builder.RegisterType<IXmlWorkerGen<User>>();

            //for registration is important last one
            //builder.RegisterType<Logger2>().As<ILogger>();
            //builder.RegisterType<Logger>().As<ILogger>();
            //builder.RegisterType<MsSql>().As<IMsSql>();
            //builder.RegisterType<Oracle>().As<IOracle>();

            //register specific interface for specific clase (And static string)
            /*
            builder.Register(c => new Logger()).Named<ILogger>("Logger1");
            builder.Register(c => new Logger2()).Named<ILogger>("Logger2");
            builder.Register(c => new MsSql("connStringMsSq", c.ResolveNamed<ILogger>("Logger1"))).As<IMsSql>();
            builder.Register(c => new Oracle("connStringOrac", c.ResolveNamed<ILogger>("Logger2"))).As<IOracle>();
            */

            //register specific interface for specific clase (but left string to be writen thrue resolve)
            /*
            builder.Register(c => new Logger()).Named<ILogger>("Logger1");
            builder.Register(c => new Logger2()).Named<ILogger>("Logger2");
            builder.Register((c, p) => new MsSql(p.Named<string>("connectionString"), c.ResolveNamed<ILogger>("Logger1"))).As<IMsSql>();
            builder.Register((c, p) => new Oracle(p.Named<string>("connectionString"), c.ResolveNamed<ILogger>("Logger2"))).As<IOracle>();
            */

            //TODO find to not register string
            //builder.Register((s, l) => new MsSql(s.ToString(), l.ResolveNamed<ILogger>("Logger1"))).As<IMsSql>();
            //builder.Register<string, ILogger>((str, lg) => new MsSql(str, lg.ResolveNamed<ILogger>("Logger2"))).As<IMsSql>();
            //builder.RegisterType<MsSql>().As<IMsSql>();

            /**/

            return builder.Build();
        }

        /// <summary>
        /// map interface with classes (automatic name == I + name)
        /// </summary>
        /// <returns></returns>
        private static IContainer MapContainerAuto()
        {
            ContainerBuilder builder = new ContainerBuilder();

            List<Type> typesAll = Assembly.GetExecutingAssembly().GetTypes().ToList();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.GetInterfaces().Length > 0 && typesAll.Where(all => all.Name.Equals("I" + t.Name)).Count() > 0).As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }

        /// <summary>
        /// show diferent linq commands for getting classes
        /// </summary>
        private static void DisplayAssemblyTypes()
        {
            Console.WriteLine("Show through Linq & reflection.");

            Console.WriteLine("--------------(get all+ types)");
            List<Type> types = Assembly.GetExecutingAssembly().GetTypes().ToList(); //.Where(t => t.Name.EndsWith("Models")).ToList();
            types.ForEach(t => Console.WriteLine(" - " + t.Name));

            Console.WriteLine("--------------(get interfaces) [Namespace.EndsWith]");
            List<Type> types2 = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace.EndsWith("Interfaces") || t.Namespace.EndsWith("Models") || t.Namespace.EndsWith("Workers")).ToList();
            types2.ForEach(t => Console.WriteLine(" - " + t.Name));

            Console.WriteLine("--------------(get types with interface)");
            List<Type> types3 = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Length > 0).ToList();
            types3.ForEach(t => Console.WriteLine(" - " + t.Name)); //all that have interface

            Console.WriteLine("--------------(each class with interface named Iclass)");
            //get all classes
            List<Type> typesAll = Assembly.GetExecutingAssembly().GetTypes().ToList();
            //each class with interface I+name
            Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Length > 0 && typesAll.Where(all => all.Name.Equals("I" + t.Name)).Count() > 0)
            .ToList().ForEach(t => Console.WriteLine(" - " + t.Name));

            Console.WriteLine("--------------");
            Console.ReadLine();

        }
    }
}
