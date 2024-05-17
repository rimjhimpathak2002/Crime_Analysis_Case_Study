using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Law_Inforcement_Agency
    {

        private int agencyID;
        private string agencyName;
        private string jurisdiction;
        private string contactInformation;
        private List<Officer> officers;

        public int AgencyID
        {
            get { return agencyID; }
            set { agencyID = value; }
        }

        public string AgencyName
        {
            get { return agencyName; }
            set { agencyName = value; }
        }

        public string Jurisdiction
        {
            get { return jurisdiction; }
            set { jurisdiction = value; }
        }

        public string ContactInformation
        {
            get { return contactInformation; }
            set { contactInformation = value; }
        }

        public List<Officer> Officers
        {
            get { return officers; }
            set { officers = value; }
        }

        // Default Constructor
        public Law_Inforcement_Agency()
        {
            officers = new List<Officer>();
        }

        // Parameterized Constructor
        public Law_Inforcement_Agency(int agencyID, string agencyName, string jurisdiction, string contactInformation)
        {
            this.agencyID = agencyID;
            this.agencyName = agencyName;
            this.jurisdiction = jurisdiction;
            this.contactInformation = contactInformation;
            officers = new List<Officer>();
        }
    }
}
