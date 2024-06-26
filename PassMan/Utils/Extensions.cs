﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassMan.Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Split string by a specific text.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parameter"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        internal static string SplitByText(this string input, string parameter, int index)
        {
            string[] output = input.Split(new string[] { parameter }, StringSplitOptions.None);
            return output[index];
        }
    }
}
