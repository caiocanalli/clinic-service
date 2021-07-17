using Clinic.Domain.Common;

namespace Clinic.Application.Common
{
    public static class Errors
    {
        public static class Default
        {
            public static Error NotFound(long? id = null)
            {
                var forId = id == null ? "" : $" for Id '{id}'";
                return new Error("record.not.found", $"Record not found{forId}");
            }

            public static Error UnprocessableEntity(string message = null)
            {
                var entityMessage = string.IsNullOrEmpty(message) ? "" : $" : {message}";
                return new Error("unprocessable.entity", $"Unprocessable entity{entityMessage}");
            }
        }
    }
}