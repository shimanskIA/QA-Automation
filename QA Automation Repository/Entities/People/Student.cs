using HW7.Entities;
using HW7.Entities.Education;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.People
{
    class Student : Person
    {
        public int GroupNumber { get; set; }
        public int Course { get; set; }
        public List<Specialty> Specialties { get; set; }
        public Student(string name, string surname, int age, int groupNumber, int course, List<Specialty> specialties) : base (name, surname, age)
        {
            GroupNumber = groupNumber;
            Course = course;
            Specialties = specialties;
        }

        public Student(string name, string surname, int age, int groupNumber, int course) : base (name, surname, age)
        {
            GroupNumber = groupNumber;
            Course = course;
            Specialties = new List<Specialty>();
        }

        public void Add(Specialty specialty)
        {
            Specialties.Add(specialty);
        }
    }
}
