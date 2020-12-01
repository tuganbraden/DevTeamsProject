using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public List<Developer> Devins { get; set; }
        public string TeamName { get; set; }
        public int HowManyHavePluralsight { get; set; }
        public string DevTeamID { get; set; }

        public DevTeam() { }

        public DevTeam(List<Developer> list, string name, string id)
        {
            TeamName = name;
            Devins = list;
            DevTeamID = id;

            int x = 0;

            foreach (Developer dev in list)
            {
                if(dev.HasPluralsight == true)
                {
                    x++;
                }
            }

            HowManyHavePluralsight = x;
        }
    }
}
