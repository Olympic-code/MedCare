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
    public class AuthenticationServiceTest : IDisposable
    {

        private PatientRepository patientRepository;
        private ProfessionalRepository professionalRepository;
        private IAuthenticationService authenticationService;

        public AuthenticationServiceTest()
        {
            DatabasesConfiguration.RunInitialConfiguration();
            authenticationService = new AuthenticationService();
            patientRepository = new PatientRepository();
            professionalRepository = new ProfessionalRepository();
        }

        [Fact]
        public async void PatientLoginWithoutAnExistingAccount()
        {

            try
            {
                Patient inexistentPatient = new Patient();
                await authenticationService.ValidateLogin("patient1@gmail.com", "123456");
                Assert.True(false);
                //throw new XunitException();
            }
            catch (NotFoundUserException e)
            {
                Assert.True(true);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void PatientLoginWithAnIncorrectPassword()
        {

            try
            {
                Patient patient = new Patient()
                {
                    Email = "patient2@gmail.com",
                    Password = "123456"
                };
                await patientRepository.AddNewPatient(patient);
                await authenticationService.ValidateLogin("patient2@gmail.com", "654321");
                await patientRepository.RemovePatient(patient);
                Assert.True(false);
            }
            catch (IncorrectPasswordException e)
            {
                Assert.True(true);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void PatientLoginWithAValidPassword()
        {

            try
            {
                Patient patient = new Patient()
                {
                    Email = "patient3@gmail.com",
                    Password = "123456"
                };
                await patientRepository.AddNewPatient(patient);
                await authenticationService.ValidateLogin("patient3@gmail.com", "123456");
                await patientRepository.RemovePatient(patient);
                Assert.True(true);
            }
            catch (IncorrectPasswordException e)
            {
                Assert.True(false);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void ProfessionalLoginWithoutAnExistingAccount()
        {

            try
            {
                Professional inexistentProfessional = new Professional();
                await authenticationService.ValidateLogin("professional1@gmail.com", "abcdef");
                Assert.True(false);
                //throw new XunitException();
            }
            catch (NotFoundUserException e)
            {
                Assert.True(true);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void ProfessionalLoginWithAnIncorrectPassword()
        {

            try
            {
                Professional professional = new Professional()
                {
                    Email = "professional2@gmail.com",
                    Password = "abcdef"
                };
                await professionalRepository.AddNewProfessional(professional);
                await authenticationService.ValidateLogin("professional2@gmail.com", "fedcba");
                await professionalRepository.RemoveProfessional(professional);
                Assert.True(false);
            }
            catch (IncorrectPasswordException e)
            {
                Assert.True(true);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void ProfessionalLoginWithAValidPassword()
        {

            try
            {
                Professional professional = new Professional()
                {
                    Email = "professional3@gmail.com",
                    Password = "abcdef"
                };
                await professionalRepository.AddNewProfessional(professional);
                Tuple<EnumUserType, int> pResult = await authenticationService.ValidateLogin("professional3@gmail.com", "abcdef");
                await professionalRepository.RemoveProfessional(professional);
                Assert.True(true);
            }
            catch (IncorrectPasswordException e)
            {
                Assert.True(false);

            }
            catch (Exception e)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        public void Dispose()
        {
            //clear actions
        }

    }
}
