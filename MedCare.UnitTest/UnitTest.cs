
using System;
using System.Threading.Tasks;
using MedCare.Commons.Entities;
using MedCare.DB.Factories;
using MedCare.DB.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedCare.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            AuthenticationService authenticationService = new AuthenticationService();
            PatientRepository patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForTests));
            Patient patient = new Patient()
            {
                Email = "patientlogin@hotmail.com",
                Password = "123456"
            };

            await patientRepository.AddNewPatient(patient);
            try
            {
                await Assert.ThrowsExceptionAsync<Exception>(()
                => authenticationService.ValidateLogin("patientlogin@hotmail.com", "654321"));
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                await patientRepository.RemovePatient(patient);
            }
        }
    }
}
