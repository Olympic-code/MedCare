using MedCare.Commons.Entities;
using MedCare.DB;
using MedCare.DB.Factories;
using MedCare.DB.Services;
using MedCare.Exceptions;
using MedCare.Services.AuthenticationServices;
using MedCare.Services.AutheticationServices;
using System;
using System.Threading.Tasks;
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
            authenticationService = new AuthenticationService(EnumDatabaseTypes.ForTests);
            patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForTests));
            professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(EnumDatabaseTypes.ForTests));
        }
        #endregion

        #region Patient Tests
        [Fact]
        public async void PatientLoginWithoutAnExistingAccount()
        {
            await Assert.ThrowsAsync<NotFoundUserException>(() 
                => authenticationService.ValidateLogin("patientlogin@hotmail.com", "123456"));
        }

        [Fact]
        public async void PatientLoginWithAnIncorrectPassword()
        {
            Patient patient = new Patient()
            {
                Email = "patientlogin@hotmail.com",
                Password = "123456"
            };

            await patientRepository.AddNewPatient(patient);
            try
            {
                await Assert.ThrowsAsync<IncorrectPasswordException>(()
                => authenticationService.ValidateLogin("patientlogin@hotmail.com", "654321"));
            } catch (Exception)
            {
                Assert.True(false);
            }
            finally
            {
                await patientRepository.RemovePatient(patient);
            }
        }

        [Fact]
        public async void PatientLoginWithAValidPassword()
        {
            Patient patient = new Patient()
            {
                Email = "patientlogin@hotmail.com",
                Password = "123456"
            };

            try
            {
                await patientRepository.AddNewPatient(patient);
                await authenticationService.ValidateLogin("patientlogin@hotmail.com", "123456");
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
            await Assert.ThrowsAsync<NotFoundUserException>(()
                => authenticationService.ValidateLogin("professionallogin@hotmail.com", "abcdef"));
        }

        [Fact]
        public async void ProfessionalLoginWithAnIncorrectPassword()
        {
            Professional professional = new Professional()
            {
                Email = "professionallogin@hotmail.com",
                Password = "abcdef"
            };

            await professionalRepository.AddNewProfessional(professional);
            try
            {
                await Assert.ThrowsAsync<IncorrectPasswordException>(()
                => authenticationService.ValidateLogin("professionallogin@hotmail.com", "fedcba"));
            }
            catch (Exception)
            {
                Assert.True(false);
            }
            finally
            {
                await professionalRepository.RemoveProfessional(professional);
            }
        }

        [Fact]
        public async void ProfessionalLoginWithAValidPassword()
        {
            Professional professional = new Professional()
            {
                Email = "professionallogin@hotmail.com",
                Password = "abcdef"
            };

            try
            {
                await professionalRepository.AddNewProfessional(professional);
                Tuple<EnumUserType, int> pResult = await authenticationService.ValidateLogin("professionallogin@hotmail.com", "abcdef");
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
