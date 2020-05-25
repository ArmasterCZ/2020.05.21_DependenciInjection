using System;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using(var mock = AutoMock.GetLoose())
            {
                //when Ioracle.GetPcDescription is called return "PC Win Unit Test"
                mock.Mock<_2020._05._21_DependenciInjection.Interfaces.IOracle>()
                    .Setup(x => x.GetPcDescription())
                    .Returns("PC Win Unit Test");

                //var cls = mock.Create<BusinessLogic>
            }
        }

        [TestMethod]
        public void TestMethod1(string input, string expected)
        {
            
        }
    }
}
