using ListGenerator.Shared.CustomExceptions;
using System;

namespace ListGenerator.Shared.Extensions
{
    public static class NullCheckingExtensions
    {
        public static void ThrowIfNull(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static void ThrowIfNullOrEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(nameof(value));
            }
        }

        public static void ThrowIfNullWithShowMessage<T>(this T value, string errorMessage) where T : class
        {
            if(value == null)
            {
                throw new ShowErrorMessageException(errorMessage);
            }
        }

        public static void ThrowIfNull<T>(this T value) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
