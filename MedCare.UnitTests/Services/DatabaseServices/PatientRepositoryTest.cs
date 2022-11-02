using MedCare.Commons.Entities;
using MedCare.DB;
using MedCare.DB.Factories;
using MedCare.DB.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async void AddingNewPatient()
        {
            string email = "patient@gmail.com";
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
        public async void AddingNewPatientWithCredentialAlredyExists()
        {
            string email = "patient@gmail.com";
            Patient patient = new Patient() { Email = email };
            Patient patientTwo = new Patient() { Email = email };

            try
            {
                await patientRepository.AddNewPatient(patient);
                await patientRepository.AddNewPatient(patientTwo);

                Assert.True(false);

            }
            catch (Exception)
            {
                Assert.True(true);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                await patientRepository.RemovePatient(patient);
                await patientRepository.RemovePatient(patientTwo);
            }
        }
        #endregion

        #region Get User Tests
        [Fact]
        public async void GetAnExistingPatient()
        {
            string email = "patient@gmail.com";
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
            string email = "patient@gmail.com";
            Patient patient = new Patient() { Email = email };
            try
            {
                Patient patientLocated = await patientRepository.GetPatient(patient);

                Assert.True(false);

            }
            catch (Exception)
            {
                Assert.True(true);
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
                    Patient patient = new Patient() { Email = "patient" + i + "@gmail.com" };
                    await patientRepository.AddNewPatient(patient);
                }

                List<Patient> allPatientsInDatabase = await patientRepository.GetAllPatients();

                Assert.NotEmpty(allPatientsInDatabase);
                Assert.Equal(10, allPatientsInDatabase.Count);
            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                for (int i = 0; i < 10; i++)
                {
                    Patient patient = new Patient() { Email = "patient" + i + "@gmail.com" };
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
                string email = "patient@gmail.com";
                Patient patient = new Patient() { Email = email };
                await patientRepository.AddNewPatient(patient);
                await patientRepository.RemovePatient(patient);
                Patient patientLocated = await patientRepository.GetPatient(patient);

                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void RemovingUnexistingPatient()
        {

            try
            {
                string email = "patient@gmail.com";
                Patient patient = new Patient() { Email = email };
                await patientRepository.RemovePatient(patient);

                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
                Console.WriteLine("Entity framework error!");
            }
        }
        #endregion
    }
}
