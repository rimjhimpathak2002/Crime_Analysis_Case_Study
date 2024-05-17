using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Incidents
    {
        public enum IncidentStatus
        {
            Open,
            Closed,
            UnderInvestigation
        }
        private int _incidentID;
        private string _incidentType;
        private DateTime _incidentDate;
        private string _location;
        private string _description;
        private string _status;
        private int _victimID;
        private int _suspectID;
        private int _agencyID;
        private List<Evidence> _evidences;
        private List<Report> _reports;

         //Default Constructor
        public Incidents()
        {
            _evidences = new List<Evidence>();
            _reports = new List<Report>();
        }

        //Parameterised Constructor
        public Incidents(int incidentID, string incidentType, DateTime incidentDate, string location, string description, string status, int victimID, int suspectID, int agencyID)
        {
            _incidentID = incidentID;
            _incidentType = incidentType;
            _incidentDate = incidentDate;
            _location = location;
            _description = description;
            _status = status;
            _victimID = victimID;
            _suspectID = suspectID;
            _agencyID = agencyID;
            _evidences = new List<Evidence>();
            _reports = new List<Report>();
        }

        public int IncidentID
        {
            get { return _incidentID; }
            set { _incidentID = value; }
        }

        public string IncidentType
        {
            get { return _incidentType; }
            set { _incidentType = value; }
        }

        public DateTime IncidentDate
        {
            get { return _incidentDate; }
            set { _incidentDate = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int VictimID
        {
            get { return _victimID; }
            set { _victimID = value; }
        }

        public int SuspectID
        {
            get { return _suspectID; }
            set { _suspectID = value; }
        }

        public int AgencyID
        {
            get { return _agencyID; }
            set { _agencyID = value; }
        }

        public List<Evidence> Evidences
        {
            get { return _evidences; }
            set { _evidences = value; }
        }

        public List<Report> Reports
        {
            get { return _reports; }
            set { _reports = value; }
        }
    }
}
