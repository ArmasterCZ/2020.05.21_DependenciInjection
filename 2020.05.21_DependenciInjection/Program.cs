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
            //DisplayAssemblyTypes();
            //Console.ReadLine();

            IContainer container = MapContainer();
            BusinessLogic businessLogic = new BusinessLogic(container);
            businessLogic.Run();
        }

        /// <summary>
        /// connect classes with interlaces (I + name)
        /// </summary>
        /// <returns>Container with liked clasees</returns>
        private static IContainer MapContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterType<User>().As<IUser>();
            //builder.RegisterType<XmlWorker>().As<IXmlWorker>();

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
            //test 
            //builder.RegisterType<IXmlWorkerGen<User>>();

            return builder.Build();
        }

        /// <summary>
        /// show diferent linq commands for getting classes
        /// </summary>
        private static void DisplayAssemblyTypes()
        {
            //get interfaces
            List<Type> types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace.EndsWith("Interfaces") || t.Namespace.EndsWith("Models") || t.Namespace.EndsWith("Workers"))
            .ToList();
            types.ForEach(t => Console.WriteLine(t.Name));

            Console.WriteLine("--------------");

            //types.ForEach(t => Console.WriteLine(t.GetInterfaces().FirstOrDefault()?.Name)); /null
            //Assembly.GetExecutingAssembly().GetTypes().ToList().ForEach(t => Console.WriteLine(t.Name)); //all classes
            Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Length > 0).ToList().ForEach(t => Console.WriteLine(t.Name)); //all that have interface

            Console.WriteLine("--------------");

            //get all classes
            List<Type> typesAll = Assembly.GetExecutingAssembly().GetTypes().ToList();

            //each class with interface I+name
            Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Length > 0 && typesAll.Where(all => all.Name.Equals("I" + t.Name)).Count() > 0)
            .ToList().ForEach(t => Console.WriteLine(t.Name));
        }
    }
}
