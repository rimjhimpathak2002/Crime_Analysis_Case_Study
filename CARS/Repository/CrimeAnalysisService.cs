using CARS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions;
using System.Data;
using System.Security.Cryptography;

namespace CARS.Repository
{
    public class CrimeAnalysisService : ICrimeAnalysisService
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        //constructor
        public CrimeAnalysisService()
        {
            sqlConnection = new SqlConnection("Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True");
            cmd = new SqlCommand();
        }
        public Boolean createIncident(Incidents incident)
        {
            string query = "INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID) VALUES (@IncidentType, @IncidentDate, @Location, @Description, @Status, @VictimID, @SuspectID)";

            cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
            cmd.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
            cmd.Parameters.AddWithValue("@Location", incident.Location);
  
            cmd.Parameters.AddWithValue("@Description", incident.Description);
            cmd.Parameters.AddWithValue("@Status", incident.Status);
            cmd.Parameters.AddWithValue("@VictimID", incident.VictimID);
            cmd.Parameters.AddWithValue("@SuspectID", incident.SuspectID);

            sqlConnection.Open();
            int addIncidentStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return addIncidentStatus > 0;
        }



        public Boolean UpdateIncidentStatus(Incidents incident, int incidentID)
        {
      
                string query = "UPDATE Incidents SET Status = @status WHERE IncidentID = @incidentId";

                cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@status", incident.Status);
                cmd.Parameters.AddWithValue("@incidentId", incidentID);

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); 
                sqlConnection.Close();
                return rowsAffected > 0;
            
        }




        public ICollection<Incidents> getIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incidents> incidents = new List<Incidents>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Incidents WHERE IncidentDate BETWEEN @StartDate AND @EndDate", sqlConnection);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    // Open the SQL connection
                    sqlConnection.Open();

                    // Execute the SQL command and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Incidents incident = new Incidents
                        {
                            IncidentID = (int)reader["IncidentId"],
                            IncidentType = (string)reader["IncidentType"],
                            IncidentDate = (DateTime)reader["IncidentDate"],
                            Description = (string)reader["Description"],
                            Status = (string)reader["Status"],
                            VictimID = (int)reader["VictimID"],
                            SuspectID = (int)reader["SuspectID"],
                        };
                        incidents.Add(incident);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return incidents;
        }




        public ICollection<Incidents> searchIncidents(Incidents criteria)
        {
            List<Incidents> incidents = new List<Incidents>();

            using (SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True"))
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Incidents WHERE IncidentType = @IncidentType";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@IncidentType", criteria.IncidentType);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Incidents ind = new Incidents
                        {
                            IncidentID = (int)reader["IncidentId"],
                            IncidentType = (string)reader["IncidentType"],
                            IncidentDate = (DateTime)reader["IncidentDate"],
                            Description = (string)reader["Description"],
                            Status = (string)reader["Status"],
                            VictimID = (int)reader["VictimID"],
                            SuspectID = (int)reader["SuspectID"]
                        };

                        incidents.Add(ind);
                    }
                }
            }
            sqlConnection.Close();
            return incidents;
        }


        // Generate incident reports
        // Parameters: Incident object
        // Return type: Report object
        public Report generateIncidentReport(Incidents incident)
        {

            Report report = null;


            string connectionString = "Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True";


            string query = "select Incidents.IncidentID, IncidentType, IncidentDate, Description, Incidents.Status, ReportingOfficer, FirstName, LastName from Incidents join Reports on Incidents.IncidentID = Reports.IncidentID join Officers on Reports.ReportingOfficer = Officers.OfficerID where IncidentID = @incidentid";


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {

                    cmd.Parameters.AddWithValue("@incidentid", incident.IncidentID);


                    sqlConnection.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            report = new Report
                            {
                                ReportID = (int)reader["ReportID"],
                                IncidentID = (int)reader["IncidentID"],
                                ReportingOfficer = (int)reader["ReportingOfficer"],
                                ReportDate = (DateTime)reader["ReportDate"],
                                ReportDetails = (string)reader["ReportDetails"],
                                Status = (string)reader["Status"]
                            };
                        }
                    }
                }
            }


            return report;
        }
        //public Report generateIncidentReport(Incidents incident)
        //{
        //    Report report = null;

        //    string connectionString = "Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True";
        //    string query = @"
        //    SELECT 
        //        Reports.ReportID, 
        //        Incidents.IncidentID, 
        //        Incidents.Description,
        //        Reports.ReportingOfficer, 
        //        Reports.ReportDate, 
        //        Reports.ReportDetails, 
        //        Incidents.Status 
                
        //    FROM 
        //        Incidents 
        //    JOIN 
        //        Reports ON Incidents.IncidentID = Reports.IncidentID 
        //    WHERE 
        //        Incidents.IncidentID = @incidentid";

        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
        //        {
        //            cmd.Parameters.AddWithValue("@incidentid", incident.IncidentID);

        //            sqlConnection.Open();

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    report = new Report
        //                    {
        //                        ReportID = reader.GetInt32(reader.GetOrdinal("ReportID")),
        //                        IncidentID = reader.GetInt32(reader.GetOrdinal("IncidentID")),
        //                        ReportingOfficer = reader.GetInt32(reader.GetOrdinal("ReportingOfficer")),
        //                        ReportDate = reader.GetDateTime(reader.GetOrdinal("ReportDate")),
        //                        ReportDetails = reader.GetString(reader.GetOrdinal("ReportDetails")),
        //                        Status = reader.GetString(reader.GetOrdinal("Status"))
        //                    };
        //                }
        //            }
        //        }
        //    }

        //    return report;
        //}

        public bool CreateCase(Cases c)
        {
            SqlConnection sqlConnection = null;
            SqlCommand cmd = null;

            try
            {
                sqlConnection = new SqlConnection("Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True");
                string query = "INSERT INTO Cases (CaseNumber, CaseDescription, CaseStatus, IncidentID, OfficerID) VALUES (@CaseNumber, @CaseDescription, @CaseStatus, @IncidentID, @OfficerID)";
                cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                cmd.Parameters.AddWithValue("@CaseNumber", c.CaseNumber);
                cmd.Parameters.AddWithValue("@CaseDescription", c.CaseDescription); 
                cmd.Parameters.AddWithValue("@CaseStatus", c.CaseStatus);
                cmd.Parameters.AddWithValue("@IncidentID", c.IncidentID);
                cmd.Parameters.AddWithValue("@OfficerID", c.OfficerID);

                int addIncidentStatus = cmd.ExecuteNonQuery();
                return addIncidentStatus > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
           
        }

        public List<Cases> GetCaseDetails(int caseID)
        {

           // Cases c = new Cases();
                List<Cases> cs = new List<Cases>();
                cmd.CommandText = "SELECT * FROM Cases where Cases.CaseID = @tid";
                cmd.Parameters.AddWithValue("@tid", caseID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cases course = new Cases();
                    course.CaseID = (int)reader["CaseID"];
                    course.CaseNumber = (string)reader["CaseNumber"];
                    course.CaseStatus = (string)reader["CaseStatus"];
                    course.CaseDescription = (string)reader["CaseDescription"];
                    course.IncidentID = (int)reader["IncidentID"];
                    course.OfficerID = (int)reader["OfficerID"];
                    cs.Add(course);
                }
                sqlConnection.Close();
                return cs;
            
          

        }
        public bool UpdateCaseDetails(Cases caseObject)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True"))
                {
                    string query = "UPDATE Cases SET CaseNumber = @CaseNumber, CaseDescription = @Description, CaseStatus = @Status WHERE CaseID = @CaseID";

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@CaseNumber", caseObject.CaseNumber);
                        cmd.Parameters.AddWithValue("@Description", caseObject.CaseDescription);
                        cmd.Parameters.AddWithValue("@Status", caseObject.CaseStatus);
                        cmd.Parameters.AddWithValue("@CaseID", caseObject.CaseID);

                        sqlConnection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        isSuccess = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return isSuccess;
        }

        public List<Cases> GetAllCases()
        {
            List<Cases> cases = new List<Cases>();

 
                using (SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True"))
                {
                    string query = "SELECT * FROM Cases";

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        // Open the SQL connection
                        sqlConnection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        // Read data and populate cases list
                        while (reader.Read())
                        {
                            Cases caseObject = new Cases
                            {
                                CaseID = (int)reader["CaseID"],
                                CaseNumber = (string)reader["CaseNumber"],
                                CaseDescription = (string)reader["CaseDescription"],
                                CaseStatus = (string)reader["CaseStatus"],
                                IncidentID = (int)reader["IncidentID"],
                                OfficerID = (int)reader["OfficerID"]
                            };
                            cases.Add(caseObject);
                        }
                    }
                
            }


            return cases;
        }

  
        public bool IncidentExists(int incidentID)
        {
            bool exists = false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-2LFUD90;Database=CARS;Trusted_Connection=True")) 
                {
                    string query = "SELECT COUNT(*) FROM Incidents WHERE IncidentID = @IncidentID";

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IncidentID", incidentID);
                        sqlConnection.Open();

                        int count = (int)cmd.ExecuteScalar();
                        exists = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return exists;
        }

        //Additional method 
        public List<Incidents> DisplayIncidents()
        {

            // Cases c = new Cases();
            List<Incidents> cs = new List<Incidents>();
            cmd.CommandText = "SELECT * FROM Incidents";
          //  cmd.Parameters.AddWithValue("@tid", caseID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Incidents course = new Incidents();
                course.IncidentID = (int)reader["IncidentID"];
                course.IncidentType = (string)reader["IncidentType"];
                course.IncidentDate = (DateTime)reader["IncidentDate"];
                course.Description = (string)reader["Description"];
                course.Status = (string)reader["Status"];
                course.SuspectID = (int)reader["SuspectID"];
                course.VictimID = (int)reader["VictimID"];
                cs.Add(course);
            }
            sqlConnection.Close();
            return cs;



        }

    }
}
