using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TelephoneDiarySystem
{
    class SaveToFile : ContactList
    {
        private static string path = @"A:\ProjectForC#\TelephoneDiarySystem\TelephoneDiarySystem";
        private string filePath = path + "Board " + 1 + ".txt";
       
        public void Saving()
        {
            using (StreamWriter writeToFile = new StreamWriter(filePath))
            {
                foreach (var item in AllContact)
                {
                    if (item.Surname == " " || item.Surname == null)
                    {
                        writeToFile.WriteLine($"{item.Name},{item.Number},{item.Category}");
                    }
                    else
                    {
                        writeToFile.WriteLine($"{item.Name},{item.Surname},{item.Number},{item.Category}");
                    }
                }
            }
        }
        public void Reading()
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
           
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                
                Contact contact = new Contact();
                contact.Name = entries[0];
                contact.Surname = entries.Count() == 4 ? entries[1] : " " ;
                contact.Number = entries.Count() == 4 ? entries[2] : entries[1];
                contact.Category = entries.Count() == 4 ? entries[3] : entries[2];

                if (AllContact.Any(x => x.Name == contact.Name) == false)
                {
                    AllContact.Add(contact);
                }
            }
           
        }
    }
}
