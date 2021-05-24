using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.People
{
    public abstract class Person : ISerializable
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        protected static int AmountOfObjects { get; set; } = 0;
        private static List<int> ForbiddenIDs { get; set; } = new List<int>();
        public XmlDocument xmlDocument { get; protected set; }
        public XmlElement peopleElement { get; protected set; }

        public Person(int id, string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Id = id;
            if (!ForbiddenIDs.Contains(id))
            {
                ForbiddenIDs.Add(id);
            }
        }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            while (ForbiddenIDs.Contains(AmountOfObjects))
            {
                AmountOfObjects++;
            }
            Id = AmountOfObjects;
            ForbiddenIDs.Add(Id);
            AmountOfObjects++;
        }

        public virtual void Serialize()
        {
            XmlAttribute idAttribute = xmlDocument.CreateAttribute("id");
            XmlAttribute nameAttribute = xmlDocument.CreateAttribute("name");
            XmlAttribute surnameAttribute = xmlDocument.CreateAttribute("surname");
            XmlAttribute ageAttribute = xmlDocument.CreateAttribute("age");

            XmlText idText = xmlDocument.CreateTextNode(Id.ToString());
            XmlText nameText = xmlDocument.CreateTextNode(Name);
            XmlText surnameText = xmlDocument.CreateTextNode(Surname);
            XmlText ageText = xmlDocument.CreateTextNode(Age.ToString());

            idAttribute.AppendChild(idText);
            nameAttribute.AppendChild(nameText);
            surnameAttribute.AppendChild(surnameText);
            ageAttribute.AppendChild(ageText);

            peopleElement.Attributes.Append(idAttribute);
            peopleElement.Attributes.Append(nameAttribute);
            peopleElement.Attributes.Append(surnameAttribute);
            peopleElement.Attributes.Append(ageAttribute);
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
