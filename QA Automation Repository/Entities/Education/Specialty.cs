using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Education
{
    class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AcademicSubject> Subjects { get; set; }
        private static int AmountOfObjects { get; set; } = 0;

        public Specialty(string name, List<AcademicSubject> subjects) 
        {
            Name = name;
            Subjects = subjects;
            Id = AmountOfObjects;
            AmountOfObjects++;
        }

        public Specialty(string name)
        {
            Name = name;
            Id = AmountOfObjects;
            AmountOfObjects++;
            Subjects = new List<AcademicSubject>();
        }

        public void Add(AcademicSubject subject)
        {
            Subjects.Add(subject);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object specialty)
        {
            if (specialty.GetType() == typeof(Specialty))
            {
                if (specialty.GetHashCode() == Id)
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
