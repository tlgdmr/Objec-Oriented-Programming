using System;
using System.Collections.Generic;
using System.Text;

namespace Administrative_System_For_The_Hospital
{
    class EmployeeList : Employees
    {
        public List<Employees> employees = new List<Employees>() {new Employees{
                number = 0,
                Name = "TOLGA DEMIR",
                shortName = "TD",
                typeOfUser = "ADMIN",
                duty = new List<DateTime>(){DateTime.Now}
            },new Employees{
                number = 1,
                Name = "ALEXANDER STOCH",
                shortName = "AS",
                typeOfUser = "DOCTOR",
                field = " UROLOGIST",
                duty = new List<DateTime>(){new DateTime(2021,11,12),new DateTime(2021,11,20),new DateTime(2021,12,01),new DateTime(2021,12,15),new DateTime(2021,12,31)}
            },new Employees{
                number = 2,
                Name = "MICHAL WYSOCKI",
                shortName = "MW",
                typeOfUser = "DOCTOR",
                field = "DERMATOLOGY",
                duty = new List<DateTime>(){new DateTime(2021,11,15),new DateTime(2021,11,25),new DateTime(2021,12,06),new DateTime(2021,12,21),new DateTime(2022,01,05)}
            },new Employees{
                number=3,
                Name = "PETER MOSSO",
                shortName = "MW",
                typeOfUser = "DOCTOR",
                field = "CARDIOLOGIST",
                duty = new List<DateTime>(){new DateTime(2021,11,18),new DateTime(2021,11,28),new DateTime(2021,12,09),new DateTime(2021,12,24),new DateTime(2021,01,08)}
            },
            new Employees{
                number = 4,
                Name = "NIKITA KRAWIEC",
                shortName = "NK",
                typeOfUser = "NURSE",
                duty = new List<DateTime>(){new DateTime(2021,11,21),new DateTime(2021,11,29),new DateTime(2021,12,12),new DateTime(2021,12,27),new DateTime(2022,01,11)}
            }};
    }
}
