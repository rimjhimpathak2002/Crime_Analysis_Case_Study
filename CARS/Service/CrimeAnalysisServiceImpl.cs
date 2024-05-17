using CARS.Model;
using CARS.myExceptions;
using CARS.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    public class CrimeAnalysisServiceImpl : ICrimeAnalysis
    {
        readonly ICrimeAnalysisService crimerepository;

        public CrimeAnalysisServiceImpl()
        {
            crimerepository = new CrimeAnalysisService();
        }


        public void CreateIncident()
        {
            Incidents incident = new Incidents();
            //  incident.Location = new Location();

            Console.WriteLine("Enter Incident Type:");
            incident.IncidentType = Console.ReadLine();

            Console.WriteLine("Enter Incident Date (yyyy-MM-dd):");
            incident.IncidentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Location:");
            incident.Location = (Console.ReadLine());


            Console.WriteLine("Enter Description:");
            incident.Description = Console.ReadLine();

            Console.WriteLine("Enter Status:");
            incident.Status = Console.ReadLine();

            Console.WriteLine("Enter Victim ID:");
            incident.VictimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Suspect ID:");
            incident.SuspectID = int.Parse(Console.ReadLine());

            bool isCreated = crimerepository.createIncident(incident);

            if (isCreated)
            {
                Console.WriteLine("Incident created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create incident.");
            }
        }
       

           
        
        public void UpdateIncidentStatus()
        {
            DisplayIncidentDetails();
            Incidents incident = new Incidents();
            try { 
            Console.WriteLine("Enter Incident ID:");
            int incidentID = int.Parse(Console.ReadLine());

            // Check if the incident ID exists in the database
            if (!crimerepository.IncidentExists(incidentID))
            {
                throw new IncidentNumberNotFoundException($"Incident with ID {incidentID} not found.");
            }

            Console.WriteLine("Enter new Status:");
            incident.Status = Console.ReadLine();

            bool isUpdated = crimerepository.UpdateIncidentStatus(incident, incidentID);

            if (isUpdated)
            {
                Console.WriteLine("Incident status updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update incident status.");
            }
        }
              catch (IncidentNumberNotFoundException ex)
            {
                Console.WriteLine("Incident Number Not Found: " + ex.Message);
            }
                catch (Exception ex)
             {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        public void GetIncidentsInDateRange()
        {
            Console.WriteLine("Enter start date (yyyy-MM-dd):");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter end date (yyyy-MM-dd):");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            ICollection<Incidents> incidents = crimerepository.getIncidentsInDateRange(startDate, endDate);

            if (incidents.Count > 0)
            {
                Console.WriteLine("Incidents within the specified date range:");
                foreach (var incident in incidents)
                {
                    Console.WriteLine($"IncidentID: {incident.IncidentID}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}, Description: {incident.Description}, Status: {incident.Status}, VictimID: {incident.VictimID}, SuspectID: {incident.SuspectID}");
                }
            }
            else
            {
                Console.WriteLine("No incidents found within the specified date range.");
            }
        }

        public void SearchIncidents()
        {
            Console.WriteLine("Enter Incident Type to search:");
            string incidentType = Console.ReadLine();

            Incidents criteria = new Incidents { IncidentType = incidentType };

            ICollection<Incidents> incidents = crimerepository.searchIncidents(criteria);

            if (incidents.Count > 0)
            {
                Console.WriteLine("Incidents found based on the provided criteria:");
                foreach (var incident in incidents)
                {
                    Console.WriteLine($"IncidentID: {incident.IncidentID}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}, Description: {incident.Description}, Status: {incident.Status}, VictimID: {incident.VictimID}, SuspectID: {incident.SuspectID}");
                }
            }
            else
            {
                Console.WriteLine("No incidents found based on the provided criteria.");
            }
        }

        public void GenerateIncidentReport()
        {
            Incidents incident = new Incidents();
            Console.WriteLine("Enter Incident ID to generate the report:");
            incident.IncidentID = Convert.ToInt32(Console.ReadLine());

            Report report = crimerepository.generateIncidentReport(incident);
            if (report != null)
            {
                Console.WriteLine("Incident Report:");
                Console.WriteLine($"ReportID: {report.ReportID}");
                Console.WriteLine($"IncidentID: {report.IncidentID}");
                Console.WriteLine($"ReportingOfficer: {report.ReportingOfficer}");
                Console.WriteLine($"ReportDate: {report.ReportDate}");
                Console.WriteLine($"ReportDetails: {report.ReportDetails}");
                Console.WriteLine($"Status: {report.Status}");
            }
            else
            {
                Console.WriteLine("No report found for the provided Incident ID.");
            }
        }


        public void CreateCases()
        {
            Cases c1 = new Cases();
            //  incident.Location = new Location();

            Console.WriteLine("Enter Case Number:");
            c1.CaseNumber= Console.ReadLine();

            Console.WriteLine("Enter Case Description:");
            c1.CaseDescription = Console.ReadLine();

            Console.WriteLine("Enter Case Status : :");
            c1.CaseStatus = Console.ReadLine();

       

            Console.WriteLine("Enter Incident ID:");
            c1.IncidentID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Officer ID:");
            c1.OfficerID = int.Parse(Console.ReadLine());

            bool isCreated = crimerepository.CreateCase(c1);

            if (isCreated)
            {
                Console.WriteLine("Incident created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create incident.");
            }
           GetAllCasesService();
        }



        public void GetCaseDetails()
        {
            try
            {
                Cases cs = new Cases();
                Console.WriteLine("Enter Case ID:");
                cs.CaseID = Convert.ToInt32(Console.ReadLine());

                List<Cases> cases = crimerepository.GetCaseDetails(cs.CaseID);

                if (cases.Count > 0)
                {
                    Console.WriteLine($"--------------- List of Cases with Case ID: {cs.CaseID} ---------------");
                    foreach (Cases c in cases)
                    {
                        Console.WriteLine($"Case ID: {c.CaseID}");
                        Console.WriteLine($"Case Number: {c.CaseNumber}");
                        Console.WriteLine($"Case Status: {c.CaseStatus}");
                        Console.WriteLine($"Case Description: {c.CaseDescription}");
                        Console.WriteLine($"Incident ID: {c.IncidentID}");
                        Console.WriteLine($"Officer ID: {c.OfficerID}");
                        Console.WriteLine("----------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No Records found with Case ID: " + cs.CaseID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

      
            public void UpdateCaseDetailsService()
            {
               GetAllCasesService();
                try
                {
                    // Prompt user to enter case details
                    Console.WriteLine("Enter Case ID:");
                    int caseID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Case Name:");
                    string caseName = Console.ReadLine();

                    Console.WriteLine("Enter Description:");
                    string description = Console.ReadLine();

                    Console.WriteLine("Enter Status:");
                    string status = Console.ReadLine();

                    // Create a Case object with user input
                    Cases caseObject = new Cases
                    {
                        CaseID = caseID,
                        CaseNumber = caseName,
                        CaseDescription = description,
                        CaseStatus = status
                    };

                    bool isSuccess = crimerepository.UpdateCaseDetails(caseObject);

                    if (isSuccess)
                    {
                        Console.WriteLine("Case details updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update case details.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            GetAllCasesService();
            }

        public void GetAllCasesService()
        {
            try
            {
                
                List<Cases> cases = crimerepository.GetAllCases();

                // Display the retrieved cases
                if (cases.Count > 0)
                {
                    Console.WriteLine("List of Cases:");
                    foreach (var caseObject in cases)
                    {
                        Console.WriteLine($"CaseID: {caseObject.CaseID}, CaseNumber: {caseObject.CaseNumber}, Description: {caseObject.CaseDescription}, Status: {caseObject.CaseStatus}, IncidentId :{caseObject.IncidentID}, OfficerId :{caseObject.OfficerID}");
                        // Add more properties as needed
                    }
                }
                else
                {
                    Console.WriteLine("No cases found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        //Additional Details 
        public void DisplayIncidentDetails()
        {
            try
            {
                Incidents cs = new Incidents();
                //Console.WriteLine("Enter Case ID:");
                //cs.CaseID = Convert.ToInt32(Console.ReadLine());

                List<Incidents> cases = crimerepository.DisplayIncidents();

                if (cases.Count > 0)
                {
                    Console.WriteLine($"--------------- List of Cases with Case ID: {cs.IncidentID} ---------------");
                    foreach(Incidents c in cases)
                    {
                        Console.WriteLine($"Incident ID: {c.IncidentID}");
                        Console.WriteLine($"Incident Type: {c.IncidentType}");
                        Console.WriteLine($"Description: {c.Description}");
                        Console.WriteLine($"Status: {c.Status}");
                        Console.WriteLine($"Suspect ID: {c.SuspectID}");
                        Console.WriteLine($"Victim ID: {c.VictimID}");
                        Console.WriteLine("----------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No Records found with Case ID: " + cs.IncidentID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
