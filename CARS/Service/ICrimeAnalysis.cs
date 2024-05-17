using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    public interface ICrimeAnalysis
    {
        public void CreateIncident();
        public void UpdateIncidentStatus();
        public void GetIncidentsInDateRange();
        public void SearchIncidents();
        public void GenerateIncidentReport();
        public void CreateCases();
        public void GetCaseDetails();
        public void UpdateCaseDetailsService();
        public void GetAllCasesService();
        public void DisplayIncidentDetails();
    }
}
