using CARS.Model;
using CARS.Repository;
using CARS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using System;

namespace CARS
{
    internal class MainModule
    {
        private ICrimeAnalysis _crimerepo;

        public MainModule()
        {
            _crimerepo = new CrimeAnalysisServiceImpl();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear(); 
                Console.WriteLine("!!.............WELCOME TO CRIME ANALYSIS AND MANAGEMENT SYSTEM................. !!!"); 

                Console.WriteLine("....................Main Menu...........................:");
                Console.WriteLine("....................1. Access Incidents Data.........................");
                Console.WriteLine("....................2. Generate Incident Report......................");
                Console.WriteLine("....................3. Search Incidents..............................");
                Console.WriteLine("....................4. Create Cases..................................");
                Console.WriteLine("....................5. Get Case Details..............................");
                Console.WriteLine("....................6. Update Case Details...........................");
                Console.WriteLine("....................7. Get all Cases.................................");
                Console.WriteLine("....................8. Display Incidents.............................");
                Console.WriteLine("....................9. Exit..........................................");
                Console.Write("Enter your Choice: ");
                int userInput;

                if (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 9)
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    Console.ReadKey();
                    continue;
                }

                if (userInput == 9)
                {
                    break;
                }

                Console.Clear();

                switch (userInput)
                {
                    case 1:
                        AccessIncidentsData();
                        break;
                    case 2:
                        _crimerepo.GenerateIncidentReport();
                        break;
                    case 3:
                        _crimerepo.SearchIncidents();
                        break;
                    case 4:
                        _crimerepo.CreateCases();
                        break;
                    case 5:
                        _crimerepo.GetCaseDetails();
                        break;
                    case 6:
                        _crimerepo.UpdateCaseDetailsService();
                        break;
                    case 7:
                        _crimerepo.GetAllCasesService();
                        break;
                    case 8:
                        _crimerepo.DisplayIncidentDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        private void AccessIncidentsData()
        {
            Console.WriteLine("!! KNOW ABOUT INCIDENT DATA !!");
            Console.WriteLine("Enter Choice from below options:");
            Console.WriteLine("1. Create Incident / Add into Incidents");
            Console.WriteLine("2. Update Incidents");
            Console.WriteLine("3. Get Incident in Date Range");
            Console.Write("Choice: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                return;
            }

            switch (choice)
            {
                case 1:
                    _crimerepo.CreateIncident();
                    break;
                case 2:
                    _crimerepo.UpdateIncidentStatus();
                    break;
                case 3:
                    _crimerepo.GetIncidentsInDateRange();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }


    }
}



