using KDG.Common.Tuples;
using Xunit;

namespace KDG.Common.Tests.Tuples
{
    public class PassFailTests
    {
        [Fact]
        public void PassFail_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var expectedPass = "Pass";
            var expectedFail = "Fail";

            // Act
            var passFail = new PassFail<string>(expectedPass, expectedFail);

            // Assert
            Assert.Equal(expectedPass, passFail.Pass);
            Assert.Equal(expectedFail, passFail.Fail);
        }

        [Fact]
        public void PassFail_InheritsFromTuple()
        {
            // Arrange & Act
            var passFail = new PassFail<int>(1, 0);

            // Assert
            Assert.IsAssignableFrom<Tuple<int, int>>(passFail);
        }

        [Fact]
        public void PassFail_PassProperty_ReturnsItem1()
        {
            // Arrange
            var passFail = new PassFail<string>("Success", "Failure");

            // Act & Assert
            Assert.Equal(passFail.Item1, passFail.Pass);
        }

        [Fact]
        public void PassFail_FailProperty_ReturnsItem2()
        {
            // Arrange
            var passFail = new PassFail<string>("Success", "Failure");

            // Act & Assert
            Assert.Equal(passFail.Item2, passFail.Fail);
        }
    }
}
