using MedCare.Commons.Entities;
using MedCare.DB;
using MedCare.DB.Services;
using MedCare.Exceptions;
using MedCare.Services.AuthenticationServices;
using MedCare.Services.AutheticationServices;
using System;
using Xunit;

namespace MedCare.UnitTests.Services
{
    public class RegisterAuthenticationServiceTest
    {
        #region Attributes and Constructor
        private PatientRepository patientRepository;
        private ProfessionalRepository professionalRepository;
        private IAuthenticationService authenticationService;

        public RegisterAuthenticationServiceTest()
        {
            DatabasesConfiguration.RunInitialConfiguration();
            authenticationService = new AuthenticationService();
            patientRepository = new PatientRepository();
            professionalRepository = new ProfessionalRepository();
        }
        #endregion

        #region Patient Tests
        [Fact]
        public async void PatientRegisterWithUnequalPasswords()
        {
            string email = "patient1@gmail.com";
            try
            {
                await authenticationService.ValidateRegistration(EnumUserType.PATIENT, "teste", "000", 18, 40028922, email, 
                    "123456", "654321", "tester", "SA00");
                Assert.True(false);

            }
            catch (PasswordsAreNotEqualsException e)
            {
                Assert.True(true);

            }
            catch (UserAlreadyExistsException e)
            {
                Assert.True(false);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                Patient patient = new Patient() { Email = email };
                await patientRepository.RemovePatient(patient);
            }
        }

        [Fact]
        public async void PatientRegisterWithAvailableEmail()
        {
            string email = "patient2@gmail.com";
            try
            {
                await authenticationService.ValidateRegistration(EnumUserType.PATIENT, "teste", "000", 18, 40028922, email,
                    "123456", "123456", "tester", "SA00");
                Assert.True(true);

            }
            catch (PasswordsAreNotEqualsException e)
            {
                Assert.True(false);

            }
            catch (UserAlreadyExistsException e)
            {
                Assert.True(false);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            } finally
            {
                Patient patient = new Patient() { Email = email };
                await patientRepository.RemovePatient(patient);
            }
        }

        [Fact]
        public async void PatientRegisterWithLinkedEmailToAnExistingUser()
        {
            string email = "patient3@gmail.com";
            Patient patient = new Patient() { Email = email };

            try
            {
                await patientRepository.AddNewPatient(patient);
                await authenticationService.ValidateRegistration(EnumUserType.PATIENT, "teste", "000", 18, 40028922, email,
                    "123456", "123456", "tester", "SA00");
                Assert.True(false);

            }
            catch (PasswordsAreNotEqualsException e)
            {
                Assert.True(false);

            }
            catch (UserAlreadyExistsException e)
            {
                Assert.True(true);

            }
            catch (Exception e)
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

        #region Professional Tests
        [Fact]
        public async void ProfessionalRegisterWithUnequalPasswords()
        {
            string email = "professional1@gmail.com";
            try
            {
                await authenticationService.ValidateRegistration(EnumUserType.PROFESSIONAL, "teste", "000", 18, 40028922, email,
                    "123456", "654321", "tester", "SA00");
                Assert.True(false);

            }
            catch (PasswordsAreNotEqualsException e)
            {
                Assert.True(true);

            }
            catch (UserAlreadyExistsException e)
            {
                Assert.True(false);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                Professional professional = new Professional() { Email = email };
                await professionalRepository.RemoveProfessional(professional);
            }
        }

        [Fact]
        public async void ProfessionalRegisterWithAvailableEmail()
        {
            string email = "professional2@gmail.com";
            try
            {
                await authenticationService.ValidateRegistration(EnumUserType.PROFESSIONAL, "teste", "000", 18, 40028922, email,
                    "123456", "123456", "tester", "SA00");
                Assert.True(true);

            }
            catch (PasswordsAreNotEqualsException e)
            {
                Assert.True(false);

            }
            catch (UserAlreadyExistsException e)
            {
                Assert.True(false);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                Professional professional = new Professional() { Email = email };
                await professionalRepository.RemoveProfessional(professional);
            }
        }

        [Fact]
        public async void ProfessionalRegisterWithLinkedEmailToAnExistingUser()
        {
            string email = "professional3@gmail.com";
            Professional professional = new Professional() { Email = email };

            try
            {
                await professionalRepository.AddNewProfessional(professional);
                await authenticationService.ValidateRegistration(EnumUserType.PROFESSIONAL, "teste", "000", 18, 40028922, email,
                    "123456", "123456", "tester", "SA00");
                Assert.True(false);

            }
            catch (PasswordsAreNotEqualsException e)
            {
                Assert.True(false);

            }
            catch (UserAlreadyExistsException e)
            {
                Assert.True(true);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                await professionalRepository.RemoveProfessional(professional);
            }
        }
        #endregion

    }
}
