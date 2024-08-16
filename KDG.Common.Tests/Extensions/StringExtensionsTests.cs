using KDG.Common.Extensions;
using Xunit;

namespace KDG.Common.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Wordify_ShouldAddSpacesBeforeUppercaseLetters()
        {
            // Arrange
            string input = "HelloWorld";

            // Act
            string result = input.Wordify();

            // Assert
            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void Wordify_ShouldTrimLeadingAndTrailingSpaces()
        {
            // Arrange
            string input = " ABCTest ";

            // Act
            string result = input.Wordify();

            // Assert
            Assert.Equal("A B C Test", result);
        }

        [Fact]
        public void Wordify_ShouldHandleEmptyString()
        {
            // Arrange
            string input = "";

            // Act
            string result = input.Wordify();

            // Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void SplitZohoMultiFieldValue_ShouldSplitByNewLine()
        {
            // Arrange
            string input = "Value1\nValue2\nValue3";

            // Act
            var result = input.SplitZohoMultiFieldValue().ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("Value1", result[0]);
            Assert.Equal("Value2", result[1]);
            Assert.Equal("Value3", result[2]);
        }

        [Fact]
        public void SplitZohoMultiFieldValue_ShouldSplitByComma()
        {
            // Arrange
            string input = "Value1,Value2,Value3";

            // Act
            var result = input.SplitZohoMultiFieldValue().ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("Value1", result[0]);
            Assert.Equal("Value2", result[1]);
            Assert.Equal("Value3", result[2]);
        }

        [Fact]
        public void SplitZohoMultiFieldValue_ShouldHandleNullInput()
        {
            // Arrange
            string? input = null;

            // Act
            var result = input.SplitZohoMultiFieldValue().ToList();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SplitZohoMultiFieldValue_ShouldHandleEmptyInput()
        {
            // Arrange
            string input = "";

            // Act
            var result = input.SplitZohoMultiFieldValue().ToList();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SplitZohoMultiFieldValue_ShouldTrimValues()
        {
            // Arrange
            string input = " Value1 , Value2 , Value3 ";

            // Act
            var result = input.SplitZohoMultiFieldValue().ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("Value1", result[0]);
            Assert.Equal("Value2", result[1]);
            Assert.Equal("Value3", result[2]);
        }
    }
}
