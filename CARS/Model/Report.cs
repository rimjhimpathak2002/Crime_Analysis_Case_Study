using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Report
    {
        public enum ReportStatus
        {
            Draft,
            Finalized
        }
        private int reportID;
        private int incidentID;
        private int reportingOfficer;
        private DateTime reportDate;
        private string reportDetails;
        private string status;

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
        }

        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }

        public int ReportingOfficer
        {
            get { return reportingOfficer; }
            set { reportingOfficer = value; }
        }

        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = value; }
        }

        public string ReportDetails
        {
            get { return reportDetails; }
            set { reportDetails = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        // Default Constructor
        public Report() { }

        // Parameterized Constructor
        public Report(int reportID, int incidentID, int reportingOfficer, DateTime reportDate, string reportDetails, string status)
        {
            this.reportID = reportID;
            this.incidentID = incidentID;
            this.reportingOfficer = reportingOfficer;
            this.reportDate = reportDate;
            this.reportDetails = reportDetails;
            this.status = status;
        }
    
}
}
