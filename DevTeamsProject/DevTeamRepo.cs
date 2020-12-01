using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();
        
        //DevTeam Create
        public void AddTeam(DevTeam newTeam)
        {
            _devTeams.Add(newTeam);
        }

        //DevTeam Read
        public List<DevTeam> ReadTeamList()
        {
            return _devTeams;
        }

        //DevTeam Update
        public bool UpdateTeam(string oldID, DevTeam newInfo)
        {
            DevTeam oldInfo = GetTeamByID(oldID);

            if (oldInfo != null)
            {
                oldInfo.Devins = newInfo.Devins;
                oldInfo.DevTeamID = newInfo.DevTeamID;
                oldInfo.HowManyHavePluralsight = newInfo.HowManyHavePluralsight;
                oldInfo.TeamName = newInfo.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool DeleteTeam(string id)
        {
            DevTeam team = GetTeamByID(id);

            if(team != null)
            {
                _devTeams.Remove(team);
                return true;
            }
            else
            { 
                return false;
            }
            
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamByID(string id)
        {
            foreach (DevTeam team in _devTeams)
            {
                if (team.DevTeamID == id)
                {
                    return team;
                }
            }

            return null;
        }
    }
}
