using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// nugets: 
/// - xunit
/// - xunit.runner.console
/// - xunit.runner.visualstudio
/// </summary>
namespace TestProject2
{
    public class Class1
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData("1", "2","2")]
        [InlineData("1", "2 ", "3")]
        [InlineData("11", "22", "4")]
        public void RandomShowOfMultipleDataTest(string input1, string input2, string expectedOutput)
        {
            int value = input1.Length + input2.Length;
            Assert.Equal(value.ToString(), expectedOutput);
        }
    }
}
