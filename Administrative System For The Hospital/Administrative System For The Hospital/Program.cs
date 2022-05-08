using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrative_System_For_The_Hospital
{
    class Program
    {
        private static EmployeeList employeeList = new EmployeeList();
        private static SaveToFile save = new SaveToFile();
        public static void Main()
        {
            save.Saving();
            save.Reading();
            Console.WriteLine("Welcome to Hospital Managment System");
            Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
            Console.WriteLine("=> Username ");
            string username = Console.ReadLine();
            Console.WriteLine("=> Password ");
            string password = Console.ReadLine();
            if (username.ToLower() =="admin"&& password.ToLower() =="admin")
            {
                Console.Clear();
                admin();
            }
            else if (username.ToLower() == "doctor" && password.ToLower() == "doctor")
            {
                Console.Clear();
                engineDoctor();
            }
            else if (username.ToLower() == "nurse" && password.ToLower() == "nurse")
            {
                Console.Clear();
                engineNurse();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Username Or Password , Please Try Again");
                Main();
            }
        }
        public static void admin()
        {
            Console.Clear();
            Console.WriteLine("✱ Logged As Admin !");
            Console.WriteLine("1. List Of Employees");
            Console.WriteLine("2. List Of Employees + duties");
            Console.WriteLine("3. Show Single User");
            Console.WriteLine("4. List Of Duties For Current Month");
            Console.WriteLine("5. Add user");
            Console.WriteLine("6. Modify User");
            Console.WriteLine("7. Delete user");
            Console.WriteLine("8. Add Duty");
            Console.WriteLine("0. Exit");
            int input = int.Parse(Console.ReadLine());
            engineAdmin(input);
        }
        public static void engineAdmin(int input)
        {
            IEngine engine = new Administrator();
            if (input == 8)
            {
                Console.Clear();
                foreach (var item in employeeList.employees)
                {
                    Console.WriteLine($"{item.number} {item.Name} ({item.shortName}) {item.typeOfUser} {item.field} {String.Join(",", item.duty)}");
                }
                Console.WriteLine("Please Select the Doctor or Nurse to Add Duty");
                int typeOfUser = int.Parse(Console.ReadLine());
                Console.WriteLine("Write date of duties e.g.(12/05/2021)");
                List<DateTime> dateList = new List<DateTime>();
                string result = Console.ReadLine();
                if (result.Contains("-"))
                {
                    string[] dateArray = result.Split('-');

                    foreach (string date in dateArray)
                    {
                        dateList.Add(DateTime.Parse(date));
                    }
                }
                else
                {
                    dateList.Add(DateTime.Parse(result));
                }
                engine.AddDuty(employeeList.employees, typeOfUser,dateList);
                Console.WriteLine("Press any Key to Continue ");
                string inputContinue = Console.ReadLine();
                admin();
            }
            if (input == 7)
            {
                Console.Clear();
                foreach (var item in employeeList.employees)
                {
                    Console.WriteLine($"{item.number} {item.Name} ({item.shortName}) {item.typeOfUser} {item.field}");
                }
                Console.WriteLine("Select Which One You Want to Delete");
                int number = int.Parse(Console.ReadLine());
                if (number != 0)
                {
                    engine.DeleteUser(employeeList.employees, number);
                    Console.WriteLine("Press Enter to continue");
                    string inputContinue = Console.ReadLine();
                    Console.Clear();
                    admin();
                }
                else
                {
                    Console.WriteLine("You cannot delete admin");
                    Console.WriteLine("Press Enter to continue");
                    string inputContinue = Console.ReadLine();
                    Console.Clear();
                    admin();
                }
            }
            if (input == 6)
            {
                Console.Clear();
                foreach (var item in employeeList.employees)
                {
                    Console.WriteLine($"{item.number} {item.Name} ({item.shortName}) {item.typeOfUser} {item.field}");
                }
                Console.WriteLine("Select Which One You Want to Modify");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Name And Surname");
                string nameSurname = Console.ReadLine();
                Console.WriteLine("Short Name");
                string shortName = Console.ReadLine();
                Console.WriteLine("Doctor , Nurse or Admin ?");
                string typeOfUser = Console.ReadLine();
                Console.WriteLine("Field");
                string field = Console.ReadLine();
                engine.ModifyUser(employeeList.employees,number,nameSurname,shortName,typeOfUser,field);
                Console.WriteLine("Prees Enter to Continue..."); 
                string inputContinue = Console.ReadLine();
                Console.Clear();
                admin();
            }
            if (input == 5)
            {
                Console.WriteLine("Name And Surname");
                string nameSurname = Console.ReadLine();
                Console.WriteLine("Short Name");
                string shortName = Console.ReadLine();
                Console.WriteLine("Doctor , Nurse or Admin ?");
                string typeOfUser = Console.ReadLine();
                Console.WriteLine("Field");
                string field = Console.ReadLine();
                engine.AddUser(employeeList.employees, nameSurname, shortName, typeOfUser, field);
                Console.WriteLine("Press enter to continue... ");
                string inputContinue = Console.ReadLine();
                if (inputContinue == "" + "")
                {
                    Console.Clear();
                    admin();
                }
            }
            if (input == 4)
            {
                Console.Clear();
                engine.ListOfDutiesForCurrentMonth(employeeList.employees);
                Console.WriteLine("Press any key to Continue");
                string continuee = Console.ReadLine();
                admin();
            }
            if (input == 3)
            {
                Console.Clear();
                engine.ShowSingleUsers(employeeList.employees);
                Console.WriteLine("Press any key to Continue..");
                string continuee = Console.ReadLine();
                Program.admin();
            }
            if (input == 2)
            {
                Console.Clear();
                engine.ListOfEmployeesAndDuties(employeeList.employees);
                Console.WriteLine("Press any Key to Continue...");
                string continuee = Console.ReadLine();
                admin();
            }
            if (input == 1)
            {
                Console.Clear();
                engine.ListOfEmployees(employeeList.employees);
                Console.WriteLine("Press any key to Continue...");
                string continuee = Console.ReadLine();
                admin();
            }
            if (input == 0)
            {
                Console.Clear();
                save.Saving();
                Main();
            }
        }
        public static void engineDoctor()
        {
            Console.WriteLine("✱ Logged As Doctor !");
            Console.WriteLine("1 Show list for the Doctors");
            Console.WriteLine("2 Show duty list");
            Console.WriteLine("3 Show duties for specific month");
            Console.WriteLine("0 Exit");
            int input = int.Parse(Console.ReadLine());
            doctor(input);
        }
        public static void doctor(int input)
        {
            IEngineDoctor engine = new Doctor();
            if (input == 1)
            {
                Console.Clear();
                engine.findDoctor(employeeList.employees);
                Console.WriteLine("Press enter to Continue...");
                string Ccontinue = Console.ReadLine();
                if (Ccontinue == "" + "")
                {
                    Console.Clear();
                    engineDoctor();
                }
            }
            else if (input == 2)
            {
                Console.Clear();
                Console.WriteLine("Write Name And Surname");
                string nameAndSurname = Console.ReadLine();
                engine.duties(employeeList.employees, nameAndSurname);
                Console.WriteLine("Press enter to Continue...");
                string Ccontinue = Console.ReadLine();
                if (Ccontinue == "" + "")
                {
                    Console.Clear();
                    engineDoctor();
                }
            }
            else if (input == 3)
            {
                Console.Clear();
                Console.WriteLine("Write Month as a number");
                int month = int.Parse(Console.ReadLine());
                engine.findDuties(employeeList.employees, month);
                Console.WriteLine("Press enter to Continue...");
                string Ccontinue = Console.ReadLine();
                if (Ccontinue == "" + "")
                {
                    Console.Clear();
                    engineDoctor();
                }
            }
            else if (input == 0)
            {
                Program.Main();
            }
        }
        public static void engineNurse()
        {
            Console.WriteLine("✱ Logged As Doctor !");
            Console.WriteLine("1 Show list for the Nurse");
            Console.WriteLine("2 Show duty list");
            Console.WriteLine("3 Show duties for specific month");
            Console.WriteLine("0 Exit");
            int input = int.Parse(Console.ReadLine());
            nurse(input);
        }
        public static void nurse(int input)
        {
            IEngineNurse engine = new Nurse();
            if (input == 1)
            {
                Console.Clear();
                engine.findNurse(employeeList.employees);
                Console.WriteLine("Press enter to Continue...");
                string Ccontinue = Console.ReadLine();
                if (Ccontinue == "" + "")
                {
                    Console.Clear();
                    engineNurse();
                }
                
            }
            else if (input == 2)
            {
                Console.Clear();
                Console.WriteLine("Write Name And Surname");
                string nameAndSurname = Console.ReadLine();
                engine.duties(employeeList.employees,nameAndSurname);
                Console.WriteLine("Press enter to Continue...");
                string Ccontinue = Console.ReadLine();
                if (Ccontinue == "" + "")
                {
                    Console.Clear();
                    engineNurse();
                }
            }
            else if (input == 3)
            {
                Console.Clear();
                Console.WriteLine("Write Month as a number");
                int month = int.Parse(Console.ReadLine());
                engine.findDuties(employeeList.employees,month);
                Console.WriteLine("Press enter to Continue...");
                string Ccontinue = Console.ReadLine();
            if (Ccontinue == "" + "")
                {
                    Console.Clear();
                    engineNurse();
                }
            }
            else if (input == 0)
            {
               Main();
            }
        }
    }
}
