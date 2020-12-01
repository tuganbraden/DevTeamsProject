using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    class ProgramUI
    {
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        private DeveloperRepo _devinRepo = new DeveloperRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            SeedMethod();
            bool keepRunning = true;
            while (keepRunning == true)
            {
                Console.Clear();
                // display functions to user
                // Display devs, display dev teams, add devs, add dev teams, add dev(s) to teams, update dev info, remove devs from teams, delete devs, delete dev teams
                Console.WriteLine("Select a menu option:\n" +
                "1. Display Dev Team List\n" +
                "2. Display Dev Team by ID\n" +
                "3. Display Developer List\n" +
                "4. Display Developer by ID\n" +
                "5. Manage Dev Teams\n" +
                "6. Manage Developers\n" +
                "7. Close application\n");

                string input = Console.ReadLine();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        DisplayDevTeams();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        DisplayTeamByID();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        DisplayDevins();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        DisplayDevinByID();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        ManageDevTeams();
                        break;
                    case "6":
                        ManageDevins();
                        break;
                    case "7":
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Good Bye!");
        }

        // Display list of dev teams
        private void DisplayDevTeams()
        {
            List<DevTeam> readList = _devTeamRepo.ReadTeamList();

            foreach(DevTeam team in readList)
            {
                Console.WriteLine($"{team.TeamName} (ID: {team.DevTeamID})");
            }
        }

        private void DisplayTeamByID()
        {
            List<DevTeam> readList = _devTeamRepo.ReadTeamList();

            foreach (DevTeam teamInList in readList)
            {
                Console.WriteLine($"{teamInList.TeamName} (ID: {teamInList.DevTeamID})");
            }
            
            Console.WriteLine("\nEnter the ID of the team you want to search for: ");
            string input = Console.ReadLine();

            DevTeam team = _devTeamRepo.GetTeamByID(input);

            if(team != null)
            {
                Console.Clear();

                Console.WriteLine($"Team Name: {team.TeamName}\n" +
                $"ID: {team.DevTeamID}\n" +
                $"How many members have PluralSight: {team.HowManyHavePluralsight}\n" +
                $"Members");
                foreach(Developer dev in team.Devins)
                {
                    Console.WriteLine($"{dev.DevName} (ID: {dev.DevID})");
                }
            }
            else
            {
                Console.WriteLine("A team with that ID could not be found");
            }
        }

        // Display list of devs
        private void DisplayDevins()
        {
            Console.Clear();

            // init a list of devs to be used and displayed here
            List<Developer> listOfDevins = _devinRepo.ReadDevinList();

            // display all devs on the list
            foreach (Developer dev in listOfDevins)
            {
                Console.WriteLine($"{dev.DevName} (ID: {dev.DevID})\n");
            }
        }

        // ask for a dev's id and display their info
        private void DisplayDevinByID()
        {
            Console.Clear();

            // prompt user and grab the id
            Console.WriteLine("Enter the ID of the Developer you are looking for: ");
            string id = Console.ReadLine();

            // grab the target Dev and their info
            Developer target = _devinRepo.GetDevinByID(id);

            // if a dev with that ID exists, display their info
            if (target != null)
            {
                Console.WriteLine($"{target.DevName}\n" +
                $"ID: {target.DevID}\n" +
                $"Has PluralSight: {target.HasPluralsight}");
            }
            else
            {
                Console.WriteLine("No Developer with that ID");
            }
        }

        // 4. go to menu to (1)add, (3)delete, (4)add devs to, or (5)remove devs from dev teams
        private void ManageDevTeams()
        {
            bool stayInMethod = true;

            while (stayInMethod == true)
            {
                Console.Clear();

                Console.WriteLine("Select a menu option:\n" +
                "1. Create a new Dev Team\n" +
                "2. Add Developer(s) to a team\n" +
                "3. Remove Developer(s) from a team\n" +
                "4. Change a team's info\n" +
                "5. Delete a team\n" +
                "6. Go back...");

                string input = Console.ReadLine();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        CreateDevTeam();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        AddDevsToTeam();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        RemoveDevsFromTeam();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        UpdateTeamInfo();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        DeleteTeam();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "6":
                        stayInMethod = false;
                        break;
                    default:
                        break;
                }
            }
        }

        // Create new DevTeam
        private void CreateDevTeam()
        {
            Console.WriteLine("Enter a team name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter an ID: ");
            string id = Console.ReadLine();

            List<Developer> devsInTeam = new List<Developer>();

            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine();

                DisplayDevins();

                Console.WriteLine("\nEnter a Developer's ID to add to the list, or enter 'quit' to move on: ");
                string input = Console.ReadLine();

                if (input != "quit")
                {
                    Developer addTo = _devinRepo.GetDevinByID(input);

                    if (addTo != null)
                    {
                        devsInTeam.Add(addTo);
                    }
                    else
                    {
                        Console.WriteLine("Developer with that ID could not be found");
                    }
                }
                else
                {
                    keepGoing = false;
                }

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();
            }

            DevTeam newTeam = new DevTeam(devsInTeam, name, id);
            _devTeamRepo.AddTeam(newTeam);
        }

        private void AddDevsToTeam()
        {
            DisplayDevTeams();
        
            Console.WriteLine("\nEnter the ID of the team you want to add to: ");
            string teamID = Console.ReadLine();
            DevTeam newTeam = _devTeamRepo.GetTeamByID(teamID);

            List<Developer> devsInTeam = newTeam.Devins;

            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine();

                DisplayDevins();

                Console.WriteLine("\nEnter a Developer's ID to add to the list, or enter 'quit' to move on: ");
                string input = Console.ReadLine();

                if (input != "quit")
                {
                    Developer addTo = _devinRepo.GetDevinByID(input);

                    if (addTo != null)
                    {
                        devsInTeam.Add(addTo);
                    }
                    else
                    {
                        Console.WriteLine("Developer with that ID could not be found");
                    }
                }
                else
                {
                    keepGoing = false;
                }
                Console.Clear();
            }

            newTeam.Devins = devsInTeam;

            bool confirm = _devTeamRepo.UpdateTeam(teamID, newTeam);

            if (confirm == true)
            {
                Console.WriteLine("Developers were successfully added.");
            }
            else
            {
                Console.WriteLine("Could not add Developers.");
            }
        }

        private void RemoveDevsFromTeam()
        {
            DisplayDevTeams();    

            Console.WriteLine("\nEnter the ID of the team you want to remove from: ");
            string teamID = Console.ReadLine();
            DevTeam newTeam = _devTeamRepo.GetTeamByID(teamID);

            List<Developer> devsInTeam = newTeam.Devins;

            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine();

                foreach(Developer dev in devsInTeam)
                {
                    Console.WriteLine($"{dev.DevName} (ID: {dev.DevID})");
                }

                Console.WriteLine("\nEnter a Developer's ID to remove from the list, or enter 'quit' to move on: ");
                string input = Console.ReadLine();

                if (input != "quit")
                {
                    Developer removeDev = _devinRepo.GetDevinByID(input);

                    if (removeDev != null)
                    {
                        devsInTeam.Remove(removeDev);
                    }
                    else
                    {
                        Console.WriteLine("Developer with that ID could not be found");
                    }
                }
                else
                {
                    keepGoing = false;
                }

                newTeam.Devins = devsInTeam;

                bool confirmTeam = _devTeamRepo.UpdateTeam(teamID, newTeam);

                if (confirmTeam == true)
                {
                    Console.WriteLine("Developers were successfully removed.");
                }
                else
                {
                    Console.WriteLine("Could not remove Developers.");
                }
                Console.Clear();
            }

            newTeam.Devins = devsInTeam;

            bool confirm = _devTeamRepo.UpdateTeam(teamID, newTeam);

            if (confirm == true)
            {
                Console.WriteLine("Developers were successfully removed.");
            }
            else
            {
                Console.WriteLine("Could not remove Developers.");
            }
        }

        private void UpdateTeamInfo()
        {
            DisplayDevTeams();    

            Console.WriteLine("\nEnter the ID of the team you want to update: ");
            string teamID = Console.ReadLine();
            DevTeam newTeam = _devTeamRepo.GetTeamByID(teamID);

            Console.Clear();

            Console.WriteLine("Enter a new name for the team");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter a new ID for the team: ");
            newTeam.DevTeamID = Console.ReadLine();

            bool confirm = _devTeamRepo.UpdateTeam(teamID, newTeam);

            if (confirm == true)
            {
                Console.WriteLine("Team was successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update team.");
            }
        }

        private void DeleteTeam()
        {
            DisplayDevTeams();

            Console.WriteLine("Enter the ID of the team you want to delete: ");
            string input = Console.ReadLine();

            bool confirm = _devTeamRepo.DeleteTeam(input);
            
            if(confirm == true)
            {
                Console.WriteLine("Team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Team could not be deleted.");
            }
        }

        // 5. go to menu to add, update, or remove developers
        private void ManageDevins()
        {
            bool stayInMethod = true;

            while (stayInMethod == true)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                "1. Add a new Developer\n" +
                "2. Update a Developer's info\n" +
                "3. Update a Developer's PluralSight status\n" +
                "4. Remove a Developer\n" +
                "5. Go back...");

                string input = Console.ReadLine();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        AddDevin();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        UpdateDevin();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        SwitchPluralSight();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        RemoveDevin();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        stayInMethod = false;
                        break;
                    default:
                        break;
                }
            }
        }

        // Add a new Developer
        private void AddDevin()
        {
            Console.WriteLine("Enter the new Developer's name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the new Developer's ID: ");
            string id = Console.ReadLine();

            bool pluralSight = PluralSightInit();

            Developer newDevin = new Developer(name, id, pluralSight);
            _devinRepo.AddDevin(newDevin);
        }

        // Update a dev's info
        private void UpdateDevin()
        {
            // display a list of devs
            DisplayDevins();

            Console.WriteLine("Enter the ID of the Developer you want to update: ");
            string id = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Enter the updated name: ");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter the updated ID: ");
            string newID = Console.ReadLine();

            bool pluralSight = PluralSightInit();

            Developer newInfo = new Developer(newName, newID, pluralSight);

            bool confirm = _devinRepo.UpdateDevInfo(id, newInfo);

            if (confirm == true)
            {
                Console.WriteLine("Developer was successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }
        }

        // PluralSight Switch
        private void SwitchPluralSight()
        {
            DisplayDevins();

            Console.WriteLine("Enter the ID of the Developer you want to update: ");
            string id = Console.ReadLine();

            bool pluralSight = PluralSightInit();

            bool confirm = _devinRepo.UpdatePluralsight(id, pluralSight);

            if (confirm == true)
            {
                Console.WriteLine("Developer was successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }
        }

        // Remove a dev by id
        private void RemoveDevin()
        {
            Console.Clear();

            // display a list of devs
            DisplayDevins();

            Console.WriteLine("Enter the ID of the Developer you want to remove: ");
            string id = Console.ReadLine();

            bool confirm = _devinRepo.DeleteDevin(id);

            if (confirm == true)
            {
                Console.WriteLine("Developer was successfully removed.");
            }
            else
            {
                Console.WriteLine("Could not remove Developer.");
            }
        }

        // Because this is annoying to have to do in the methods
        private bool PluralSightInit()
        {
            Console.WriteLine("Does the Developer have PluralSight? (y/n) ");
            string psight = Console.ReadLine().ToLower();

            if (psight == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SeedMethod()
        {
            Developer james = new Developer("James", "14163", true);
            _devinRepo.AddDevin(james);
            Developer charles = new Developer("Charles", "73462", false);
            _devinRepo.AddDevin(charles);
            Developer cindy = new Developer("Cindy", "86753", false);
            _devinRepo.AddDevin(cindy);
            Developer julio = new Developer("Julio", "55555", true);
            _devinRepo.AddDevin(julio);
            Developer linda = new Developer("Linda", "64389", true);
            _devinRepo.AddDevin(linda);

            List<Developer> fStix = new List<Developer>();
            fStix.Add(julio);
            fStix.Add(cindy);
            DevTeam flyingSticks = new DevTeam(fStix, "The Flying Sticks", "23");
            _devTeamRepo.AddTeam(flyingSticks);

            List<Developer> bigC = new List<Developer>();
            bigC.Add(james);
            bigC.Add(charles);
            bigC.Add(linda);
            DevTeam bigCode = new DevTeam(bigC, "Big Code", "47");
            _devTeamRepo.AddTeam(bigCode);
        }
    }
}
