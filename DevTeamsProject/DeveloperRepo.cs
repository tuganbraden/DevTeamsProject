using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create 
        public void AddDevin(Developer newDevin)
        {
            _developerDirectory.Add(newDevin);
        }

        //Developer Read
        public List<Developer> ReadDevinList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateDevInfo(string oldDevID, Developer newDevin)
        {
            Developer oldDevInfo = GetDevinByID(oldDevID);

            if (oldDevInfo != null)
            {
                oldDevInfo.DevName = newDevin.DevName;
                oldDevInfo.DevID = newDevin.DevID;
                oldDevInfo.HasPluralsight = newDevin.HasPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePluralsight(string devID, bool newStatus)
        {
            Developer devin = GetDevinByID(devID);

            if (devin != null)
            {
                devin.HasPluralsight = newStatus;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
        public bool DeleteDevin(string devID)
        {
            Developer devin = GetDevinByID(devID);

            if (devin != null)
            {
                _developerDirectory.Remove(devin);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDevinByID(string id)
        { 
            foreach(Developer dev in _developerDirectory)
            {
                if(dev.DevID == id)
                {
                    return dev;
                }
            }

            return null;
        }
    }
}
