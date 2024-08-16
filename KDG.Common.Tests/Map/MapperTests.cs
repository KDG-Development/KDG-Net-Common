using System;
using KDG.Common.Map;
using Xunit;


namespace KDG.Common.Tests.Map
{
    public class MapperTests
    {
        [Fact]
        public void Mapper_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string expectedColumn = "TestColumn";
            Func<TestClass, object?> expectedGetter = obj => obj.TestProperty;

            // Act
            var mapper = new Mapper<TestClass>(expectedColumn, expectedGetter);

            // Assert
            Assert.Equal(expectedColumn, mapper.Column);
            Assert.Same(expectedGetter, mapper.Getter);
        }

        [Fact]
        public void Mapper_Getter_ReturnsCorrectValue()
        {
            // Arrange
            var testObj = new TestClass { TestProperty = "TestValue" };
            var mapper = new Mapper<TestClass>("TestColumn", obj => obj.TestProperty);

            // Act
            var result = mapper.Getter(testObj);

            // Assert
            Assert.Equal("TestValue", result);
        }

        private class TestClass
        {
            public string? TestProperty { get; set; }
        }
    }
}
