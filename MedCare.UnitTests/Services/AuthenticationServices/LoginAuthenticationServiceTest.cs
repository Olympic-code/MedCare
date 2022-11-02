using MedCare.Commons.Entities;
using MedCare.DB;
using MedCare.DB.Factories;
using MedCare.DB.Services;
using MedCare.Exceptions;
using MedCare.Services.AuthenticationServices;
using MedCare.Services.AutheticationServices;
using System;
using Xunit;

namespace MedCare.UnitTests.Services
{
    public class LoginAuthenticationServiceTest
    {
        #region Attributes and Constructor
        private PatientRepository patientRepository;
        private ProfessionalRepository professionalRepository;
        private IAuthenticationService authenticationService;

        public LoginAuthenticationServiceTest()
        {
            DatabasesConfiguration.RunInitialConfigurationForTests();
            authenticationService = new AuthenticationService();
            patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForTests));
            professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(EnumDatabaseTypes.ForTests));
        }
        #endregion

        #region Patient Tests
        [Fact]
        public async void PatientLoginWithoutAnExistingAccount()
        {

            try
            {
                await authenticationService.ValidateLogin("patient1@gmail.com", "123456");
                Assert.True(false);

            }
            catch (NotFoundUserException)
            {
                Assert.True(true);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void PatientLoginWithAnIncorrectPassword()
        {
            Patient patient = new Patient()
            {
                Email = "patient2@gmail.com",
                Password = "123456"
            };

            try
            {
                await patientRepository.AddNewPatient(patient);
                await authenticationService.ValidateLogin("patient2@gmail.com", "654321");
                Assert.True(false);

            }
            catch (IncorrectPasswordException)
            {
                Assert.True(true);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            } finally
            {
                await patientRepository.RemovePatient(patient);
            }
        }

        [Fact]
        public async void PatientLoginWithAValidPassword()
        {
            Patient patient = new Patient()
            {
                Email = "patient3@gmail.com",
                Password = "123456"
            };

            try
            {
                await patientRepository.AddNewPatient(patient);
                await authenticationService.ValidateLogin("patient3@gmail.com", "123456");
                Assert.True(true);

            }
            catch (IncorrectPasswordException)
            {
                Assert.True(false);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            } finally
            {
                await patientRepository.RemovePatient(patient);
            }
        }
        #endregion

        #region Professional Tests
        [Fact]
        public async void ProfessionalLoginWithoutAnExistingAccount()
        {

            try
            {
                await authenticationService.ValidateLogin("professional1@gmail.com", "abcdef");
                Assert.True(false);

            }
            catch (NotFoundUserException)
            {
                Assert.True(true);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void ProfessionalLoginWithAnIncorrectPassword()
        {
            Professional professional = new Professional()
            {
                Email = "professional2@gmail.com",
                Password = "abcdef"
            };

            try
            {
                await professionalRepository.AddNewProfessional(professional);
                await authenticationService.ValidateLogin("professional2@gmail.com", "fedcba");
                Assert.True(false);

            }
            catch (IncorrectPasswordException)
            {
                Assert.True(true);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            } finally
            {
                await professionalRepository.RemoveProfessional(professional);
            }
        }

        [Fact]
        public async void ProfessionalLoginWithAValidPassword()
        {
            Professional professional = new Professional()
            {
                Email = "professional3@gmail.com",
                Password = "abcdef"
            };

            try
            {
                await professionalRepository.AddNewProfessional(professional);
                Tuple<EnumUserType, int> pResult = await authenticationService.ValidateLogin("professional3@gmail.com", "abcdef");
                Assert.True(true);

            }
            catch (IncorrectPasswordException)
            {
                Assert.True(false);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            } finally
            {
                await professionalRepository.RemoveProfessional(professional);
            }
        }
        #endregion

    }
}
