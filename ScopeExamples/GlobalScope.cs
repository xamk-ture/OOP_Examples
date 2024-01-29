using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScopeExamples
{
    /// <summary>
    /// This class can be accessed from anywhere
    /// </summary>
    public class GlobalScope
    {
        /// <summary>
        /// This property can be accessed outside of this class
        /// </summary>
        public string GlobalString = "I am a global string";

        /// <summary>
        /// This cannot be accessed outside of this class
        /// </summary>
        private string privateString = "I am a private string";

    }

    /// <summary>
    /// This class can only be accessed from within this assembly
    /// </summary>
    protected class InternalClass
    {
        public string InternalString = "I am a global string";
    }

    public static class Tester
    {
        public static void Test()
        {
            GlobalScope globalScope = new();
            Console.WriteLine(globalScope.GlobalString);

            InternalClass internalClass = new();
            Console.WriteLine(internalClass.InternalString);
        }
    }
}
