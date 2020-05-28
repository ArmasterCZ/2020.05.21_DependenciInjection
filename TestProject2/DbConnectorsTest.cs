using _2020._05._21_DependenciInjection;
using _2020._05._21_DependenciInjection.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject2
{
    public class DbConnectorsTest
    {
        //moq
        private readonly MsSql msSql;
        private readonly Oracle oracle;
        private readonly Mock<ILogger> logger = new Mock<ILogger>();
        private readonly Mock<IMsSql> dbMsSql = new Mock<IMsSql>();

        public DbConnectorsTest()
        {
            msSql = new MsSql("staticMsSqlConnectionString", logger.Object);
            oracle = new Oracle("staticMsSqlConnectionString", logger.Object);
        }

        [Fact]
        public void DbWorkerGetListOfPcMock()
        {
            //arrange
            //List<PcDto> sampleData = new List<PcDto>() { new PcDto() { Id = 1, Name = "MujPc", Description = "afsddsgdfg" } }; //should be real expected data.
            List<PcDto> retData;

            //act
            retData = msSql.GetListOfPcs();

            //assert
            //Assert.Equal(retData.Count, sampleData.Count);
            logger.Verify(x => x.LogInfo("Query - getting list of PC"),Times.Once);
            logger.Verify(x => x.LogError(It.IsAny<string>()), Times.Never);

        }
    }
}
