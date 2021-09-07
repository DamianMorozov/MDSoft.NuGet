﻿using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace MDSoft.WinFormsUtilsTests
{
    /// <summary>
    /// Utilites.
    /// </summary>
    public static class Utils
    {
        internal static void MethodStart([CallerMemberName] string memberName = "")
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{memberName} start.");
        }

        internal static void MethodComplete([CallerMemberName] string memberName = "")
        {
            TestContext.WriteLine($@"{memberName} complete.");
        }
    }
}
