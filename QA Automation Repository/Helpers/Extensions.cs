using HW7.Entities.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW7.Helpers
{
    public static class UniversityExtension
    {
        public static List<AcademicSubject> GetDoubledSubjects(this University university)
        {
            var subjects = university.Specialties.Select(x => x.Subjects);
            List<AcademicSubject> uniqueSubjects = new List<AcademicSubject>();
            List<AcademicSubject> doubledSubjects = new List<AcademicSubject>();
            foreach (List<AcademicSubject> subjectgroup in subjects)
            {
                foreach (AcademicSubject subject in subjectgroup)
                {
                    if (uniqueSubjects.Contains(subject))
                    {
                        doubledSubjects.Add(subject);
                    }
                    else
                    {
                        uniqueSubjects.Add(subject);
                    }
                }
            }
            return doubledSubjects;
        }
    }
}
