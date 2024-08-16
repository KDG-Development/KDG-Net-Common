using KDG.Common.Extensions;
using KDG.Common.Tuples;
using System;
using System.Collections.Generic;
using Xunit;

namespace KDG.Common.Tests.Extensions
{
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void ApplyFilter_WithValidInput_ReturnsCorrectPassFail()
        {
            // Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            Func<int, bool> isEven = x => x % 2 == 0;

            // Act
            var result = numbers.ApplyFilter(isEven);

            // Assert
            Assert.Equal(new List<int> { 2, 4 }, result.Pass);
            Assert.Equal(new List<int> { 1, 3, 5 }, result.Fail);
        }

        [Fact]
        public void ApplyFilter_WithEmptySource_ReturnsEmptyLists()
        {
            // Arrange
            var emptyList = new List<string>();
            Func<string, bool> alwaysTrue = _ => true;

            // Act
            var result = emptyList.ApplyFilter(alwaysTrue);

            // Assert
            Assert.Empty(result.Pass);
            Assert.Empty(result.Fail);
        }

        [Fact]
        public void ApplyFilter_WithAllPassingPredicate_ReturnsAllInPass()
        {
            // Arrange
            var strings = new List<string> { "a", "b", "c" };
            Func<string, bool> alwaysTrue = _ => true;

            // Act
            var result = strings.ApplyFilter(alwaysTrue);

            // Assert
            Assert.Equal(strings, result.Pass);
            Assert.Empty(result.Fail);
        }

        [Fact]
        public void ApplyFilter_WithAllFailingPredicate_ReturnsAllInFail()
        {
            // Arrange
            var numbers = new List<int> { 1, 2, 3 };
            Func<int, bool> alwaysFalse = _ => false;

            // Act
            var result = numbers.ApplyFilter(alwaysFalse);

            // Assert
            Assert.Empty(result.Pass);
            Assert.Equal(numbers, result.Fail);
        }

        [Fact]
        public void ApplyFilter_WithMixedResults_ReturnsCorrectPassFail()
        {
            // Arrange
            var words = new List<string> { "apple", "banana", "cherry", "date" };
            Func<string, bool> startsWithB = s => s.StartsWith("b", StringComparison.OrdinalIgnoreCase);

            // Act
            var result = words.ApplyFilter(startsWithB);

            // Assert
            Assert.Single(result.Pass);
            Assert.Equal("banana", result.Pass[0]);
            Assert.Equal(3, result.Fail.Count);
            Assert.Contains("apple", result.Fail);
            Assert.Contains("cherry", result.Fail);
            Assert.Contains("date", result.Fail);
        }
    }
}
