using CARS.Model;
using CARS.Repository;
using CARS.Service;
using NUnit.Framework;
using System.Data.SqlClient;

namespace CARS.Test
{
    public class Class1
    {
        [TestFixture]
        public class CrimeAnalysisServiceTests
        {
            private CrimeAnalysisService _crimeAnalysisService;
            private string _connectionString;

            [SetUp]
            public void Setup()
            {
                // Set up the connection string for the actual database
                _connectionString = "Server=DESKTOP-2LFUD90;Database=SISDB;Trusted_Connection=True";

                // Initialize the CrimeAnalysisService with the actual database connection
                _crimeAnalysisService = new CrimeAnalysisService();
            }

            [Test]
            public void CreateIncident_ShouldCreateIncidentWithProvidedAttributes()
            {
                // Arrange
                Incidents expectedIncident = new Incidents
                {
                    IncidentID = 14,
                    IncidentType = "Theft",
                    Description = "abs",
                    IncidentDate = DateTime.Parse("2024-12-12")
                };
                string expectedStatus = "Open";

                // Act
                bool result = _crimeAnalysisService.createIncident(expectedIncident);

                // Assert
                Assert.That(result, Is.True);

                // Now you can write additional assertions to verify that the incident was correctly created in the database
                // You can query the database to check if the incident with the provided attributes and status exists
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Incidents WHERE IncidentId = @IncidentId", connection);
                    command.Parameters.AddWithValue("@IncidentId", expectedIncident.IncidentID);
                    int count = (int)command.ExecuteScalar();
                    Assert.That(count, Is.EqualTo(1)); // Ensure that one row (incident) exists with the provided IncidentId
                }
            }
        }
    }
}
