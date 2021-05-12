using System;

namespace SuperSocket.Common
{
    /// <summary>
    /// String extension class
    /// </summary>
    public static partial class StringExtension
    {
        /// <summary>
        /// Convert string to int32.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static int ToInt32(this string source)
        {
            return source.ToInt32(0);
        }

        /// <summary>
        /// Convert string to int32.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int ToInt32(this string source, int defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;


            if (!int.TryParse(source, out int value))
                value = defaultValue;

            return value;
        }

        /// <summary>
        /// Convert string to long.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static long ToLong(this string source)
        {
            return source.ToLong(0);
        }

        /// <summary>
        /// Convert string to long.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static long ToLong(this string source, long defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;


            if (!long.TryParse(source, out long value))
                value = defaultValue;

            return value;
        }

        /// <summary>
        /// Convert string to short.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static short ToShort(this string source)
        {
            return source.ToShort(0);
        }

        /// <summary>
        /// Convert string to short.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static short ToShort(this string source, short defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;


            if (!short.TryParse(source, out short value))
                value = defaultValue;

            return value;
        }

        /// <summary>
        /// Convert string to decimal.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string source)
        {
            return source.ToDecimal(0);
        }

        /// <summary>
        /// Convert string to decimal.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string source, decimal defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;


            if (!decimal.TryParse(source, out decimal value))
                value = defaultValue;

            return value;
        }

        /// <summary>
        /// Convert string to date time.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string source)
        {
            return source.ToDateTime(DateTime.MinValue);
        }

        /// <summary>
        /// Convert string to date time.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string source, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;


            if (!DateTime.TryParse(source, out DateTime value))
                value = defaultValue;

            return value;
        }

        /// <summary>
        /// Convert string to boolean.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static bool ToBoolean(this string source)
        {
            return source.ToBoolean(false);
        }

        /// <summary>
        /// Convert string tp boolean.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns></returns>
        public static bool ToBoolean(this string source, bool defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;


            if (!bool.TryParse(source, out bool value))
                value = defaultValue;

            return value;
        }


        /// <summary>
        /// Tries parse string to enum.
        /// </summary>
        /// <typeparam name="T">the enum type</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="enumValue">The enum value.</param>
        /// <returns></returns>
        public static bool TryParseEnum<T>(this string value, bool ignoreCase, out T enumValue)
            where T : struct
        {
            return Enum.TryParse<T>(value, ignoreCase, out enumValue);
        }
    }
}
