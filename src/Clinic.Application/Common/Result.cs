using System;
using Clinic.Domain.Common;

namespace Clinic.Application.Common
{
    public class Result
    {
        public bool Success { get; }
        public bool Failure { get; }
        public Error Error { get; }

        protected Result(bool success, Error error)
        {
            if (success && error != null)
            {
                throw new ArgumentException(
                    "A result cannot be successful and contain an error");
            }

            if (success == false && error == null)
            {
                throw new ArgumentException(
                    "A failing result needs to contain an error message");
            }

            Success = success;
            Failure = !success;
            Error = error;
        }

        public static Result Ok() =>
            new(true, null);

        public static Result<T> Ok<T>(T value) =>
            new(value, true, null);

        public static Result Fail(Error error) =>
            new(false, error);

        public static Result<T> Fail<T>(Error error) =>
            new(default(T), false, error);
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        protected internal Result(T value, bool success, Error error) : base(success, error)
        {
            if (success && value == null)
            {
                throw new ArgumentException(
                    "A result cannot succeed and does not contain a value");
            }

            if (success == false && value != null)
            {
                throw new ArgumentException(
                    "A failed result cannot contain a value");
            }

            Value = value;
        }
    }
}