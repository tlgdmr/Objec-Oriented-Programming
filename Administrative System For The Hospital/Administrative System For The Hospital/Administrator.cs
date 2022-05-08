using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administrative_System_For_The_Hospital
{
    class Administrator : IEngine
    {
        public void AddDuty(List<Employees> employees, int input, List<DateTime> dateList)
        {
            Employees update = new Employees() { duty = dateList };
            var employee = employees.Where(x => x.number == input).FirstOrDefault();
            employee.duty = update.duty;
        }
        public void DeleteUser(List<Employees> employees, int number)
        {
            employees.RemoveAt(number);
        }
        public void ModifyUser(List<Employees> employees, int number, string nameSurname, string shortName, string typeOfUser, string field)
        {
            employees.RemoveAt(number);
            employees.Insert(number, new Employees
            {
                Name = nameSurname.ToUpper(),
                shortName = shortName.ToUpper(),
                typeOfUser = typeOfUser.ToUpper(),
                field = field.ToUpper()
            });
        }
        public void AddUser(List<Employees> employees, string nameSurname, string shortName, string typeOfUser, string field)
        {
            employees.Add(new Employees
            {
                number = employees.Count,
                Name = nameSurname.ToUpper(),
                shortName = shortName.ToUpper(),
                typeOfUser = typeOfUser.ToUpper(),
                field = field.ToUpper()
            });
        }
        public void ListOfDutiesForCurrentMonth(List<Employees> employees)
        {
            
            var employee = employees.Where(x => x.duty.Any(c => c.Month == DateTime.Now.Month)).ToList();
            foreach (var item in employee)
            {
                Console.WriteLine($"{item.Name} {String.Join("-" , item.duty)}");
            }
            
        }
        public void ListOfEmployees(List<Employees> employees)
        {
            foreach (var item in employees)
            {
                Console.WriteLine($"{item.number} {item.Name} ({item.shortName}) {item.typeOfUser} {item.field}");
            }
        }
        public void ListOfEmployeesAndDuties(List<Employees> employees)
        {
            foreach (var item in employees)
            {
                Console.WriteLine($"{item.number} {item.Name} ({item.shortName}) {item.typeOfUser} {item.field} {String.Join(",", item.duty)}");
            }
        }
        public void ShowSingleUsers(List<Employees> employees)
        {
            foreach (var item in employees)
            {
                Console.WriteLine($"{item.Name}");
            }
        }
    }
}
