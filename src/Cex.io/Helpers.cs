﻿using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Nextmethod.Cex
{
    public static class Helpers
    {

        #region Encoding Helpers

        private static readonly Encoding StringEncoder = Encoding.UTF8;

        public static byte[] EncodeString(string value)
        {
            value = value ?? string.Empty;
            return StringEncoder.GetBytes(value);
        }

        public static string DecodeBytes(byte[] value)
        {
            return StringEncoder.GetString(value);
        }

        #endregion


        #region Timestamp Helpers

        internal static readonly DateTime EpochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime TimestampToUtcDateTime(uint timestamp)
        {
            return EpochStart.AddSeconds(timestamp).ToUniversalTime();
        }

        public static uint UtcDateTimeToTimestamp(DateTime? value = null)
        {
            var dateTime = value != null ? value.Value : DateTime.UtcNow;
            return Convert.ToUInt32((dateTime - EpochStart).TotalSeconds);
        }

        #endregion

        #region Primitive Converters

        public static long ToLong(this uint This)
        {
            return Convert.ToInt64(This);
        }

        #endregion


    }
}