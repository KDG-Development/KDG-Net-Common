using Microsoft.FSharp.Core;

namespace KDG.Common
{

    /// <summary>
    /// Represents an optional value, compatible with F# option types
    /// </summary>
    /// <typeparam name="T">The type of the optional value</typeparam>
    public sealed class Option<T>
    {
        private readonly FSharpOption<T> _value;

        private Option(FSharpOption<T> value)
        {
            _value = value;
        }

        /// <summary>
        /// Creates an Option containing the specified value (for value types)
        /// </summary>
        public static Option<A> Some<A>(A value) where A : struct
            => new Option<A>(FSharpOption<A>.Some(value));

        /// <summary>
        /// Creates an Option containing the specified value (for reference types)
        /// </summary>
        public static Option<TRef> SomeRef<TRef>(TRef value) where TRef : class
            => new Option<TRef>(FSharpOption<TRef>.Some(value));

        /// <summary>
        /// Creates an empty Option
        /// </summary>
        public static Option<T> None => new Option<T>(FSharpOption<T>.None);

        /// <summary>
        /// Gets the underlying F# option
        /// </summary>
        public FSharpOption<T> Value => _value;

        /// <summary>
        /// Matches the Option with handlers for Some and None cases
        /// </summary>
        /// <param name="some">Function to handle the Some case</param>
        /// <param name="none">Function to handle the None case</param>
        /// <returns>The result of the matched function</returns>
        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
            => FSharpOption<T>.get_IsSome(_value)
                ? some(_value.Value)
                : none();

        /// <summary>
        /// Checks if this Option contains a value
        /// </summary>
        public bool IsSome()
            => FSharpOption<T>.get_IsSome(_value);

        /// <summary>
        /// Checks if this Option is empty
        /// </summary>
        public bool IsNone()
            => FSharpOption<T>.get_IsNone(_value);

        /// <summary>
        /// Maps the contained value to a new Option using the provided mapping function (for value types)
        /// </summary>
        /// <param name="mapper">Function to transform the value if present</param>
        /// <returns>A new Option containing the mapped value, or None if this Option was None</returns>
        public Option<TResult> Map<TResult>(Func<T, TResult> mapper) where TResult : struct
            => Match(
                some: value => Option<TResult>.Some(mapper(value)),
                none: () => Option<TResult>.None
            );

        /// <summary>
        /// Maps the contained value to a new Option using the provided mapping function (for reference types)
        /// </summary>
        /// <param name="mapper">Function to transform the value if present</param>
        /// <returns>A new Option containing the mapped value, or None if this Option was None</returns>
        public Option<TResult> MapRef<TResult>(Func<T, TResult> mapper) where TResult : class
            => Match(
                some: value => Option<TResult>.SomeRef(mapper(value)),
                none: () => Option<TResult>.None
            );
    }
    /// <summary>
    /// Provides extension methods and utilities for working with F# Option types in C#
    /// </summary>
    public static class Option
    {
        /// <summary>
        /// Creates an Option containing the specified value (for value types)
        /// </summary>
        public static Option<T> Some<T>(T value) where T : struct
            => Option<T>.Some(value);

        /// <summary>
        /// Creates an Option containing the specified value (for reference types)
        /// </summary>
        public static Option<T> SomeRef<T>(T value) where T : class
            => Option<T>.SomeRef(value);

        /// <summary>
        /// Creates an empty Option
        /// </summary>
        public static Option<T> None<T>()
            => Option<T>.None;

        /// <summary>
        /// Converts a nullable value to an Option
        /// </summary>
        public static Option<T> ToOption<T>(this T? value) where T : class
            => value is null ? Option<T>.None : Option<T>.SomeRef(value);

        /// <summary>
        /// Converts a nullable value type to an Option
        /// </summary>
        public static Option<T> ToOption<T>(this T? value) where T : struct
            => value.HasValue ? Option<T>.Some(value.Value) : Option<T>.None;

        /// <summary>
        /// Matches an Option with handlers for Some and None cases
        /// </summary>
        /// <param name="option">The option to match</param>
        /// <param name="some">Function to handle the Some case</param>
        /// <param name="none">Function to handle the None case</param>
        /// <returns>The result of the matched function</returns>
        public static TResult Match<T, TResult>(this Option<T> option, Func<T, TResult> some, Func<TResult> none)
            => option.Match(some, none);

        /// <summary>
        /// Maps an Option to a new Option using the provided mapping function
        /// </summary>
        /// <param name="option">The option to map</param>
        /// <param name="mapper">Function to transform the value if present</param>
        /// <returns>A new Option containing the mapped value, or None if the input was None</returns>
        public static Option<TResult> Map<T, TResult>(this Option<T> option, Func<T, TResult> mapper) where TResult : struct
            => option.Match(
                value => Some(mapper(value)),
                () => None<TResult>()
            );

        public static Option<TResult> MapRef<T, TResult>(this Option<T> option, Func<T, TResult> mapper) where TResult : class
            => option.Match(
                value => SomeRef(mapper(value)),
                () => None<TResult>()
            );

        /// <summary>
        /// Checks if an Option is None
        /// </summary>
        /// <param name="option">The option to check</param>
        /// <returns>True if the option is None, false otherwise</returns>
        public static bool IsNone<T>(this Option<T> option)
            => option.IsNone();

        /// <summary>
        /// Checks if an Option contains a value (is Some)
        /// </summary>
        /// <param name="option">The option to check</param>
        /// <returns>True if the option contains a value, false otherwise</returns>
        public static bool IsSome<T>(this Option<T> option)
            => option.IsSome();
    }
}