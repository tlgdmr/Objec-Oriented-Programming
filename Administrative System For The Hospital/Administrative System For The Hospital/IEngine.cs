using System;
using System.Collections.Generic;
using System.Text;

namespace Administrative_System_For_The_Hospital
{
    interface IEngine
    {
        public void ListOfEmployees(List<Employees> employees);
        public void ShowSingleUsers(List<Employees> employees);
        public void ListOfDutiesForCurrentMonth(List<Employees> employees);
        public void ListOfEmployeesAndDuties(List<Employees> employees);
        public void AddUser(List<Employees> employees, string nameSurname, string shortName, string typeOfUser, string field);
        public void ModifyUser(List<Employees> employees, int number, string nameSurname, string shortName, string typeOfUser, string field);
        public void DeleteUser(List<Employees> employees, int number);
        public void AddDuty(List<Employees> employees, int typeOfUser, List<DateTime> dateList);
    }
    interface IEngineNurse
    {
        public void findNurse(List<Employees> employees);
        public void duties(List<Employees> employees, string nameAndSurname);
        public void findDuties(List<Employees> employees, int month);
    }
    interface IEngineDoctor
    {
        public void findDoctor(List<Employees> employees);
        public void duties(List<Employees> employees, string nameAndSurname);
        public void findDuties(List<Employees> employees, int month);
    }
}
