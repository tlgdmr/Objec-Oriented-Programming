using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Administrative_System_For_The_Hospital
{
    class Doctor : IEngineDoctor 
    {
        public EmployeeList employeeList = new EmployeeList();
        public void findDoctor(List<Employees> employees)
        {
            var employee = employeeList.employees.Where(x => x.typeOfUser == "DOCTOR");
            foreach (var item in employee)
            {
                Console.WriteLine($"{item.number} {item.Name} ({item.shortName}) {item.field}");
            }
            
        }
        public void duties(List<Employees> employees, string nameAndSurname)
        {
            var employee = employeeList.employees.Where(x => x.Name == nameAndSurname.ToUpper()).ToList();
            foreach (var item in employee)
            {
                Console.WriteLine(String.Join("-", item.duty));
            }
            
        }
        public void findDuties(List<Employees> employees, int month)
        {
            var employee = employeeList.employees.Where(x => x.duty.Any(c => c.Month == month) && x.typeOfUser == "DOCTOR").ToList();
            foreach (var item in employee)
            {
                Console.WriteLine($"{item.Name} {String.Join(",", item.duty)}");
            }
            
        }
    }
}
