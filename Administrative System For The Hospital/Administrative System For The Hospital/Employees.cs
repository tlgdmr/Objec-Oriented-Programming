using System;
using System.Collections.Generic;
using System.Text;

namespace Administrative_System_For_The_Hospital
{
    class Employees
    {
        public string Name { get; set; }
        public string shortName { get; set; }
        public string typeOfUser { get; set; }
        public string field { get; set; }
        public List<DateTime> duty { get; set; }
        public int number { get; set; }
    }
}
