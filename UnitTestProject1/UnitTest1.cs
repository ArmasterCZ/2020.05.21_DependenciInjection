using System;
using System.Collections.Generic;
using System.IO;
using _2020._05._21_DependenciInjection;
using _2020._05._21_DependenciInjection.Interfaces;
using Autofac;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void DbWorkerCreateRecord()
        {
            //reset setting
            if (File.Exists("Record.txt"))
            {
                File.Delete("Record.txt");
            }

            //internal is visible because [assembly:InternalsVisibleTo("UnitTestProject1")] in AssemblyInfo.cs
            IOracle connectorOracle = new Oracle("", new Logger2());
            connectorOracle.CreateNewRecord();

            Assert.IsTrue(File.Exists("Record.txt"));
            //C:\Users\valdaufj\source\repos\ArmasterCZ\2020.05.21_DependenciInjection\UnitTestProject1\bin\Debug

        }

        /*
        [TestMethod]
        public void TestMethod1()
        {
            using(var mock = AutoMock.GetLoose())
            {
                //when Ioracle.GetPcDescription is called return "PC Win Unit Test"
                mock.Mock<_2020._05._21_DependenciInjection.Interfaces.IOracle>()
                    .Setup(x => x.GetPcDescription())
                    .Returns("PC Win Unit Test");

                IContainer container = Program.MapContainer();
                var businessLogic = mock.Create<BusinessLogic>(new NamedParameter("container", container));
                businessLogic.Run();
            }
        }

        [TestMethod]
        public void DbWorkerCreateRecordMock()
        {
            //reset setting
            if (File.Exists("Record.txt"))
            {
                File.Delete("Record.txt");
            }

            //cannot mock class itself... probably.
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IOracle>().Setup(x => x.CreateNewRecord());
                mock.Mock<ILogger>().Setup(x => x.LogInfo(""));

                Oracle oracle = mock.Create<Oracle>(); //(new NamedParameter("connectionString", new Logger2()));
                oracle.CreateNewRecord();
            }

            Assert.IsTrue(!File.Exists("Record.txt"));

        }

        [TestMethod]
        public void DbWorkerGetListOfPcMock()
        {
            //arrange
            List<PcDto> sampleData = new List<PcDto>() { new PcDto() { Id = 1, Name = "MujPc", Description = "afsddsgdfg" } };
            List<PcDto> retData;

            //act



            //using (var mock = AutoMock.GetLoose())
            //{
            //    mock.Mock<IOracle>().Setup(x => x.GetListOfPcs()).Returns(sampleData);
            //    Oracle oracle = mock.Create<Oracle>(new NamedParameter("connectionString", new Logger2()));
            //    retData = oracle.GetListOfPcs();
            //}

            //assert
            //Assert.IsTrue(retData.Count == sampleData.Count);

        }

        [TestMethod]
        public void MsSqlConnectionTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //when Ioracle.GetPcDescription is called return "PC Win Unit Test"
                mock.Mock<ILogger>()
                    .Setup(x => x.LogInfo(""));

                mock.Create<ILogger>().LogInfo("");

                //IContainer container = Program.MapContainer();
                //var businessLogic = mock.Create<BusinessLogic>(new NamedParameter("container", container));
                //businessLogic.Run();

                mock.Mock<ILogger>().Verify(x => x.LogInfo(""), Moq.Times.Once);


            }
        }*/
    }
}
