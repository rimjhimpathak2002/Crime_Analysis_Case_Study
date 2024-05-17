using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Cases
    {
     
        public int   CaseID
        
            //get { return CaseID; }
            //set { CaseID = value; }
            { get; set; }
        

        public string CaseNumber { get; set; }
        public string CaseDescription { get; set; }
     
        public string CaseStatus { get; set; }
    
        public int IncidentID { get; set; }
       
        public int OfficerID { get; set; }
        // Other properties as needed

        public Cases()
            {
               
            }
        
    }
}
