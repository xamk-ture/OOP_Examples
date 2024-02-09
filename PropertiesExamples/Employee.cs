using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesExamples
{
    public class Employee
    {
        private int age;

        // Property Age manages age field value
        public int Age
        {
            get { return age; } // Getteri returns age field value
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ikä ei voi olla negatiivinen.");
                }
                age = value; // Setteri sets age field valuen, if value is valid
            }
        }
    }
}
