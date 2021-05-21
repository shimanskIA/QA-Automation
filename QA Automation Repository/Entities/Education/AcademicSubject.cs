using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Education
{
    class AcademicSubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCreditSubject { get; set; }
        private static int AmountOfObjects { get; set; } = 0;
        
        public AcademicSubject(string name, string description, bool isCreditSubject)
        {
            Name = name;
            Description = description;
            IsCreditSubject = isCreditSubject;
            Id = AmountOfObjects;
            AmountOfObjects++;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object subject)
        {
            if (subject.GetType() == typeof(AcademicSubject))
            {
                if (subject.GetHashCode() == Id)
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
