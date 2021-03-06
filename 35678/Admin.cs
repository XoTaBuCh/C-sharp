﻿using System;

namespace Project
{
    class Admin : Worker, IWork
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
        public void Working(int people)
        {
            Subordinates += people;
            Console.WriteLine("Админа {1} поработал, управляя {0} людьми", Subordinates, FullName);
        }
        public delegate void Messange(string mes);
        public event Messange Notify;
        public override void Work(int days)
        {
            if (days < 0)
            {
                throw new Exception("Количество дней не может быть меньше нуля.");
            }
            Info.Salary *= Subordinates;
            Notify?.Invoke($"Зарплата для админа {FullName} изменилась на {Subordinates}$");
            base.Work(days);
        }
    }
}
