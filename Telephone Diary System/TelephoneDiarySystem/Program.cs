using System;
using System.Linq;


namespace TelephoneDiarySystem
{
    class Program : ContactList
    {
        private static ContactManagment contact = new ContactManagment();

        private static SaveToFile saving = new SaveToFile();
        static void Main(string[] args)
        {
            
            saving.Reading();
            
            //contact.AllContact.Sort((x, y) => x.Name.CompareTo(y.Name));

            Console.WriteLine("1) Show Contact");
            Console.WriteLine("2) Add Contact");
            Console.WriteLine("3) Edit Contact");
            Console.WriteLine("4) Delete Contact");
            Console.WriteLine("5) Save And Exit");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                contact.ShowContact();
            }
            else if (number == 2)
            {
                contact.AddContact();
            }
            else if (number == 3)
            {
                contact.EditContact();
            }
            else if (number == 4)
            {
                contact.DeleteContact();
            }
            else
            {
                saving.Saving();
                Environment.Exit(1);
            }
            Console.WriteLine("Enter to Continue");
            string input = Console.ReadLine();
            
            Console.Clear();
            Main(null);
        }
       
    }
}
