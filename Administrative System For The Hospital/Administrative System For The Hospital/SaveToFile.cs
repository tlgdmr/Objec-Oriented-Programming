using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;


namespace Administrative_System_For_The_Hospital
{
    class SaveToFile : EmployeeList
    {
        private static string path = @"A:\ProjectForC#\HospitalManagement\";
        private string filePath = path + "Board " + 1 + ".txt";

        public void Saving()
        {
            using (StreamWriter writeToFile = new StreamWriter(filePath))
            {
                foreach (var item in employees)
                {
                    writeToFile.WriteLine($"{item.Name} ,({item.shortName}) ,{item.typeOfUser} ,{item.field} ,{item.number}");
                }
            }
        }
        public void Reading()
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                Employees getEmploye = new Employees();

                getEmploye.Name = entries[0];
                getEmploye.shortName = entries[1];
                getEmploye.typeOfUser = entries[2];
                getEmploye.field = entries[3];

                employees.Add(getEmploye);
            }

        }
    }
}
