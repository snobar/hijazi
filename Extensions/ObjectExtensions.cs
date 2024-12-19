﻿using System.Reflection;

namespace hijazi.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNotNullOrEmpty<T>(this T? value) where T : struct
        {
            return value.HasValue;
        }

        public static bool IsNotNullOrEmpty<T>(this T data)
        {
            if (data is null)
            {
                return false;
            }

            return true;
        }

        public static bool IsNotNullOrEmpty(this object obj)
        {
            if (obj is null)
                return false;

            return obj.GetType().GetRuntimeProperties().Any(property =>
            {
                object value = property.GetValue(obj);
                return (value is not null);
            });
        }
    }
}