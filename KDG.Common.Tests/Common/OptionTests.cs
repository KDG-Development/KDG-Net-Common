using Microsoft.AspNetCore.Mvc;
using Microsoft.FSharp.Core;
using Xunit;

namespace KDG.Common.Tests.Common
{
    public class OptionTests
    {

        [Fact]
        public void GenericOption_Some_CreatesOptionWithValue()
        {
            // Arrange
            int value = 42;

            // Act
            var option = Option<int>.Some(value);

            // Assert
            Assert.True(option.IsSome());
            Assert.Equal(value, option.Value.Value);
        }

        [Fact]
        public void GenericOption_SomeRef_CreatesOptionWithReferenceValue()
        {
            // Arrange
            string value = "test";

            // Act
            var option = Option<string>.SomeRef(value);

            // Assert
            Assert.True(option.IsSome());
            Assert.Equal(value, option.Value.Value);
        }

        [Fact]
        public void GenericOption_Match_HandlesSomeCase()
        {
            // Arrange
            int value = 42;
            var option = Option<int>.Some(value);
            string expected = "Value is 42";

            // Act
            var result = option.Match(
                some: v => $"Value is {v}",
                none: () => "No value"
            );

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenericOption_Match_HandlesNoneCase()
        {
            // Arrange
            var option = Option<int>.None;
            string expected = "No value";

            // Act
            var result = option.Match(
                some: v => $"Value is {v}",
                none: () => "No value"
            );

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenericOption_None_CreatesEmptyOption()
        {
            // Act
            var option = Option<string>.None;

            // Assert
            Assert.True(FSharpOption<string>.get_IsNone(option.Value));
        }

        [Fact]
        public void ToOption_NonNullReferenceType_ReturnsSomea()
        {
            // Arrange
            string? value = "test";

            var temp = FSharpOption<string>.Some(value);

            // Act
            var option = value.ToOption();

            // Assert
            Assert.True(option.IsSome());
            Assert.Equal(value, option.Value);
        }


        [Fact]
        public void Some_CreatesOptionWithValue()
        {
            // Arrange
            var value = "test";

            // Act
            var option = Option.SomeRef(value);

            // Assert
            Assert.True(option.IsSome());
            Assert.Equal(value, option.Value);
        }

        [Fact]
        public void None_CreatesEmptyOption()
        {
            // Act
            var option = Option.None<string>();

            // Assert
            Assert.True(option.IsNone());
        }

        [Fact]
        public void ToOption_NullReferenceType_ReturnsNone()
        {
            // Arrange
            string? value = null;

            // Act
            var option = value.ToOption();

            // Assert
            Assert.True(option.IsNone());
        }

        [Fact]
        public void ToOption_NonNullReferenceType_ReturnsSome()
        {
            // Arrange
            string value = "test";

            // Act
            var option = value.ToOption();

            // Assert
            Assert.True(option.IsSome());
            Assert.Equal(value, option.Value);
        }

        [Fact]
        public void ToOption_NullableValueType_WithoutValue_ReturnsNone()
        {
            // Arrange
            int? value = null;

            // Act
            var option = value.ToOption();

            // Assert
            Assert.True(option.IsNone());
        }

        [Fact]
        public void ToOption_NullableValueType_WithValue_ReturnsSome()
        {
            // Arrange
            int? value = 42;

            int temp1 = 42;

            var temp = Option.Some(temp1);

            // Act
            var option = value.ToOption();

            // Assert
            Assert.True(option.IsSome());
            Assert.Equal(value.Value, option.Value);
        }

        [Fact]
        public void Match_WithSome_CallsSomeFunction()
        {
            // Arrange
            var option = Option.SomeRef("test");

            // Act
            var result = option.Match(
                some: v => $"Some({v})",
                none: () => "None"
            );

            // Assert
            Assert.Equal("Some(test)", result);
        }

        [Fact]
        public void Match_WithNone_CallsNoneFunction()
        {
            // Arrange
            var option = Option.None<string>();

            // Act
            var result = option.Match(
                some: v => $"Some({v})",
                none: () => "None"
            );

            // Assert
            Assert.Equal("None", result);
        }

        [Fact]
        public void Map_WithSome_TransformsValue()
        {
            // Arrange
            var option = Option.Some(42);

            // Act
            var result = option.Map(x => x * 2);

            // Assert
            Assert.True(result.IsSome());
            Assert.Equal(84, result.Value);
        }

        [Fact]
        public void Map_WithNone_ReturnsNone()
        {
            // Arrange
            var option = Option.None<int>();

            // Act
            var result = option.Map(x => x * 2);

            // Assert
            Assert.True(result.IsNone());
        }
    }
}
