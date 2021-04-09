﻿using System;

namespace Project
{
    class Admin : Worker
    {
        public int Subordinates;
        public Admin() : base()
        {
            Subordinates = 1;
        }
        public Admin(string fullName, string identifier) : base(fullName, identifier)
        {
            Subordinates = 1;
        }
        public Admin(string fullName, string identifier, bool isMale, DateTime dateOfBirth, Human mother, Human father, int salary, WorkingHours hours, int projects) : base(fullName, identifier, isMale, dateOfBirth, mother, father, salary, hours)
        {
            Subordinates = projects;
        }
        public override string ToString()
        {
            return string.Format("{0}, id={1}, salary={2}$, subordinates={3}", FullName, Identifier, Info.Salary, Subordinates);
        }
        public void AddPeople(int people)
        {
            Subordinates = people;
        }
        public override void Work(int days)
        {
            Info.Salary *= Subordinates;
            Console.WriteLine("Зарплата для админа {1} изменилась на {0}$", Subordinates, FullName);
            base.Work(days);
        }
    }
}