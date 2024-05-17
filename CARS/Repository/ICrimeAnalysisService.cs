using CARS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    internal interface ICrimeAnalysisService
    {
        public Boolean createIncident(Incidents incident);

        public bool UpdateIncidentStatus(Incidents incident, int incidentID);
        public ICollection<Incidents> getIncidentsInDateRange(DateTime startDate, DateTime endDate);
        public ICollection<Incidents> searchIncidents(Incidents criteria);

        public Report generateIncidentReport(Incidents incident);

        public Boolean CreateCase(Cases cased);

        public List<Cases> GetCaseDetails(int caseId);

        public bool UpdateCaseDetails(Cases caseObject);

        public List<Cases> GetAllCases();

        public bool IncidentExists(int incidentID);

        //Additional Service 
        public List<Incidents> DisplayIncidents();

    }
}
