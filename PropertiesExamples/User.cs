using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesExamples
{
    public class User
    {
        /// <summary>
        /// Property for the user's name
        /// </summary>
        public string Name { get => name; 
            set => name = value; }

        private string privateName;
        private string name;

        public string Name3;

        /// <summary>
        /// Example of a property with a private backing field. 
        /// This is what the compiler does for you when you use the shorthand property syntax
        /// </summary>
        public string Name2
        {
            get
            {
                return privateName;
            }
            set
            { 

                privateName = value; 
            }
        }

        /// <summary>
        /// Full method for getting the user's name, that get represents
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return privateName;
        }

        /// <summary>
        /// Full method for setting the user's name, that set represents
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            privateName = name;
        }

    }
}
