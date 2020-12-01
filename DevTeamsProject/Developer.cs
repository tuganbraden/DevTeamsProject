using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string DevName { get; set; }
        public string DevID { get; set; }
        public bool HasPluralsight { get; set; }

        public Developer() { }

        public Developer(string name, string id, bool pluralsight)
        {
            DevName = name;
            DevID = id;
            HasPluralsight = pluralsight;
        }
    }
}
