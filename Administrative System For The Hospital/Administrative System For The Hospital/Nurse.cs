using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administrative_System_For_The_Hospital
{
    class Nurse : IEngineNurse
    {
        public void findNurse(List<Employees> employees)
        {
            var employee = employees.Where(x => x.typeOfUser == "NURSE");
            foreach (var item in employee)
            {
                Console.WriteLine($"{item.number} {item.Name} ({item.shortName}) {item.field}");
            }
            
        }
        public void duties(List<Employees> employees, string nameAndSurname)
        {
            var employee = employees.Where(x => x.Name == nameAndSurname.ToUpper()).ToList();
            foreach (var item in employee)
            {
                Console.WriteLine(String.Join("-", item.duty));
            }
            
        }
        public void findDuties(List<Employees> employees,int month)
        {
            var employee = employees.Where(x => x.duty.Any(c => c.Month == month) && x.typeOfUser == "NURSE").ToList();
            foreach (var item in employee)
            {
                Console.WriteLine($"{item.Name} {String.Join(",", item.duty)}");
            }
        }
    }
}
