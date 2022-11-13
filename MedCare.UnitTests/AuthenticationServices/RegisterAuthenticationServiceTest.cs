using System;
using MedCare.Application.Exceptions;
using MedCare.Application.Services.AuthenticationService;
using MedCare.Commons.Entities;
using MedCare.DB;
using MedCare.DB.Factories;
using MedCare.DB.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedCare.UnitTests.AuthenticationServices
{
    [TestClass]
    public class RegisterAuthenticationServiceTest
    {
        #region Attributes and Constructor
        private PatientRepository patientRepository;
        private ProfessionalRepository professionalRepository;
        private IAuthenticationService authenticationService;

        [TestInitialize]
        public void Initializate()
        {
            DatabasesConfiguration.RunInitialConfiguration();
            authenticationService = new AuthenticationService(EnumDatabaseTypes.ForTests);
            patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForTests));
            professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(EnumDatabaseTypes.ForTests));
        }
        #endregion

        #region Patient Tests
        [TestMethod]
        public async void PatientRegisterWithUnequalPasswords()
        {
            string email = "patientregister@hotmail.com";
            try
            {
                await Assert.ThrowsExceptionAsync<PasswordsAreNotEqualsException>(()
                => authenticationService.ValidateRegistration(EnumUserType.PATIENT, "teste", "000", 18, 40028922,
                    email, "123456", "654321", "tester", "SA00"));
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Patient patient = new Patient() { Email = email };
                await patientRepository.RemovePatient(patient);
            }
        }

        [TestMethod]
        public async void PatientRegisterWithAvailableEmail()
        {
            string email = "patientregister@hotmail.com";
            try
            {
                await authenticationService.ValidateRegistration(EnumUserType.PATIENT, "teste", "000", 18, 40028922, email,
                    "123456", "123456", "tester", "SA00");
                Assert.IsTrue(true);

            }
            catch (Exception)
            {
                Assert.IsTrue(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                Patient patient = new Patient() { Email = email };
                await patientRepository.RemovePatient(patient);
            }
        }

        [TestMethod]
        public async void PatientRegisterWithLinkedEmailToAnExistingUser()
        {
            string email = "patientregister@hotmail.com";
            Patient patient = new Patient() { Email = email };
            try
            {
                await patientRepository.AddNewPatient(patient);
                await Assert.ThrowsExceptionAsync<UserAlreadyExistsException>(()
                => authenticationService.ValidateRegistration(EnumUserType.PATIENT, "teste", "000", 18, 40028922,
                    email, "123456", "123456", "tester", "SA00"));
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
        #endregion

        #region Professional Tests
        [TestMethod]
        public async void ProfessionalRegisterWithUnequalPasswords()
        {
            string email = "professionalregister@hotmail.com";
            try
            {
                await Assert.ThrowsExceptionAsync<PasswordsAreNotEqualsException>(()
                => authenticationService.ValidateRegistration(EnumUserType.PROFESSIONAL, "teste", "000", 18, 40028922,
                email, "123456", "654321", "tester", "SA00"));
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Professional professional = new Professional() { Email = email };
                await professionalRepository.RemoveProfessional(professional);
            }
        }

        [TestMethod]
        public async void ProfessionalRegisterWithAvailableEmail()
        {
            string email = "professionalregister@hotmail.com";
            try
            {
                await authenticationService.ValidateRegistration(EnumUserType.PROFESSIONAL, "teste", "000", 18, 40028922,
                email, "123456", "123456", "tester", "SA00");
                Assert.IsTrue(true);

            }
            catch (Exception)
            {
                Assert.IsTrue(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                Professional professional = new Professional() { Email = email };
                await professionalRepository.RemoveProfessional(professional);
            }
        }

        [TestMethod]
        public async void ProfessionalRegisterWithLinkedEmailToAnExistingUser()
        {
            string email = "professionalregister@hotmail.com";
            Professional professional = new Professional() { Email = email };
            try
            {
                await professionalRepository.AddNewProfessional(professional);
                await Assert.ThrowsExceptionAsync<UserAlreadyExistsException>(()
                => authenticationService.ValidateRegistration(EnumUserType.PROFESSIONAL, "teste", "000", 18, 40028922,
                email, "123456", "123456", "tester", "SA00"));
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                await professionalRepository.RemoveProfessional(professional);
            }
        }
        #endregion

    }
}
