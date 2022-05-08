using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TelephoneDiarySystem
{
    class ContactManagment : ContactList
    {
        public void AddContact()
        {
            Console.Clear();
            Console.WriteLine("Name");
            string name = Console.ReadLine();
            Console.WriteLine("Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Number");
            string number = Console.ReadLine();
            Console.WriteLine("Category");
            string category = Console.ReadLine();
            AllContact.Add(new Contact
            {
                Name = name.ToUpper(),
                Surname = surname.ToUpper(),
                Number = number,
                Category = category.ToUpper()
            });
            Console.Clear();
            foreach (var item in AllContact)
            {
                if (item.Surname == " ")
                {
                    Console.WriteLine($"{item.Name} \n{item.Number} \n{item.Category}");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine($"{item.Name} \n{item.Surname} \n{item.Number} \n{item.Category}");
                    Console.WriteLine(" ");
                }

            }
        }
        public void DeleteContact()
        {
            Console.Clear();
            Console.Clear();
            foreach (var item in AllContact)
            {
                if (item.Surname == " " || item.Surname == null)
                {
                    Console.WriteLine($"{item.Name} \n{item.Number} \n{item.Category}");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine($"{item.Name} \n{item.Surname} \n{item.Number} \n{item.Category}");
                    Console.WriteLine(" ");
                }

            }
            Console.WriteLine("Write Name to Delete");
            string name = Console.ReadLine().ToUpper();
            AllContact.RemoveAll(x => x.Name == name);
        }
        public void EditContact()
        {
            Console.Clear();
            Console.WriteLine("Write Name to Edit");
            string name = Console.ReadLine().ToUpper();
            AllContact.RemoveAll(x => x.Name == name);

            Console.WriteLine("Name");
            string Name_ = Console.ReadLine();
            Console.WriteLine("Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Number");
            string number = Console.ReadLine();
            Console.WriteLine("Category");
            string category = Console.ReadLine();
            AllContact.Add(new Contact
            {
                Name = Name_.ToUpper(),
                Surname = surname.ToUpper(),
                Number = number,
                Category = category.ToUpper()
            });
        }
        public void ShowContact() 
        {
            Console.Clear();
            foreach (var item in AllContact)
            {
                if (item.Surname == " " || item.Surname == null)
                {
                    Console.WriteLine($"{item.Name} \n{item.Number} \n{item.Category}");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine($"{item.Name} \n{item.Surname} \n{item.Number} \n{item.Category}");
                    Console.WriteLine(" ");
                }
                
            }
        }
    }
}
