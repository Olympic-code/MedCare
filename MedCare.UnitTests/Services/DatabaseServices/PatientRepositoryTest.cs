using MedCare.Commons.Entities;
using MedCare.DB;
using MedCare.DB.Factories;
using MedCare.DB.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace MedCare.UnitTests.Services.DatabaseServices
{
    public class PatientRepositoryTest
    {
        #region Attributes and Constructor
        private PatientRepository patientRepository;

        public PatientRepositoryTest()
        {
            DatabasesConfiguration.RunInitialConfigurationForTests();
            patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForTests));
        }
        #endregion

        #region Create Users Tests
        [Fact]
        public async void CreateNewPatient()
        {
            string email = "patientrepository@gmail.com";
            Patient patient = new Patient() { Email = email };

            try
            {
                bool addResult = await patientRepository.AddNewPatient(patient);

                Assert.True(addResult);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                await patientRepository.RemovePatient(patient);
            }
        }
        #endregion

        #region Get User Tests
        [Fact]
        public async void GetAnExistingPatient()
        {
            string email = "patientrepository@gmail.com";
            Patient patient = new Patient() { Email = email };

            try
            {
                await patientRepository.AddNewPatient(patient);
                Patient patientLocated = await patientRepository.GetPatient(patient);

                Assert.Equal(email, patientLocated.Email);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                await patientRepository.RemovePatient(patient);
            }
        }

        [Fact]
        public async void GetAnUnexistingPatient()
        {
            string email = "patientrepository@gmail.com";
            Patient patient = new Patient() { Email = email };
            try
            {
                Patient patientLocated = await patientRepository.GetPatient(patient);

                Assert.Null(patientLocated);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }
        #endregion

        #region Get All Users Tests
        [Fact]
        public async void GetAllPatientsWithEmptyDatabase()
        {

            try
            {
                List<Patient> allPatientsInDatabase = await patientRepository.GetAllPatients();

                Assert.Empty(allPatientsInDatabase);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void GetAllPatients()
        {

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Patient patient = new Patient() { Email = "patientrepository" + i + "@gmail.com" };
                    await patientRepository.AddNewPatient(patient);
                }

                List<Patient> allPatientsInDatabase = await patientRepository.GetAllPatients();

                Assert.NotEmpty(allPatientsInDatabase);
                Assert.Equal(10, allPatientsInDatabase.Count);
            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                for (int i = 0; i < 10; i++)
                {
                    Patient patient = new Patient() { Email = "patientrepository" + i + "@gmail.com" };
                    await patientRepository.RemovePatient(patient);
                }
            }
        }
        #endregion

        #region Delete Users Tests
        [Fact]
        public async void RemovingExistingPatient()
        {

            try
            {
                string email = "patientrepository@gmail.com";
                Patient patient = new Patient() { Email = email };
                await patientRepository.AddNewPatient(patient);
                bool removeResult = await patientRepository.RemovePatient(patient);

                Assert.True(removeResult);
            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void RemovingUnexistingPatient()
        {

            try
            {
                string email = "patientrepository@gmail.com";
                Patient patient = new Patient() { Email = email };
                bool removeResult = await patientRepository.RemovePatient(patient);

                Assert.False(removeResult);
            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }
        #endregion
    }
}
