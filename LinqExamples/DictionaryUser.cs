using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    public class DictionaryUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public DictionaryUser(int id, string name, string email, string address)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
        }
    }
}
