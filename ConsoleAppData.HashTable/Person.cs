using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.HashTable
{
    public class Person
    {
        public int Id { get; }
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
            Id = GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}, {Age} лет, {Gender} пола";
        }

        public override int GetHashCode()
        {
            var nameKey = 0;
            for (int i = 0; i < Name.Length; i++)
            {
                nameKey += (int)Name[i];
            }
            return Name.Length + Age + Gender * 10 + nameKey;
        }

        public override bool Equals(object obj)
        {
            if (this.ToString() == obj.ToString()) { return true; }
            else return false;
        }

    }
}
