using CARS.Model;
using CARS.Repository;

namespace CARS_Test
{
    public class Tests
    {
       


        [Test]
        public void Test1()
        {
            CrimeAnalysisService crimeAnalysisService = new CrimeAnalysisService();
            Incidents expectedIncident = new Incidents
            {
                IncidentType = "Theft",
                IncidentDate = DateTime.Parse("2024-05-01"),
                Location = "Street 34",
                Description = "Car break-in, laptop stolen",
                Status = "Open",
                VictimID = 101,
                SuspectID = 11,
            };

            bool result = crimeAnalysisService.createIncident(expectedIncident);

            Assert.That(result, Is.True);

        }
        [Test]
        public void Test2()
        {
            CrimeAnalysisService crimeAnalysisService = new CrimeAnalysisService();
            Incidents updatedIncident = new Incidents
            {
                IncidentType = "Theft",
                IncidentDate = DateTime.Parse("2024-05-01"),
                Location = "Street 34",
                Description = "Car break-in, laptop stolen",
                Status = "Open",
                VictimID = 101,
                SuspectID = 11,
            };

            bool result = crimeAnalysisService.createIncident(updatedIncident);

            Assert.That(result, Is.True);

        }
    }
}