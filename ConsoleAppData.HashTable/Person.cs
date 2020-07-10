using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.HashTable
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }

        public Person()
        {

        }
        public Person(string name, int age, int gender = 0)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.Length + Age + Gender * 1000 + (int)Name[0]; 
        }
    }
}
