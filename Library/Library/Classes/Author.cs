using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Author
    {
        public String Name { get; set; }

        public Author() { }
        public Author(String firstName, String lastName)
        {
            Name = $"{firstName} {lastName}";
        }
        public Author(String name)
        {
            Name = name;
        }

    }
}
