using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.People
{
    class StaffWorker : Worker
    {
        public StaffVacancies Vacancy { get; set; }
        public StaffWorker(string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty, StaffVacancies vacancy) : base(name, surname, age, experience, loan, administrationDuty)
        {
            Vacancy = vacancy;
        }
    }
}
