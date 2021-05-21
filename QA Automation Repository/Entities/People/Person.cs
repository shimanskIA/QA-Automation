using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.People
{
    abstract class Person
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        protected static int AmountOfObjects { get; set; } = 0;

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Id = AmountOfObjects;
            AmountOfObjects++;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object person)
        {
            if (person.GetType() == typeof(Person))
            {
                if (person.GetHashCode() == Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
