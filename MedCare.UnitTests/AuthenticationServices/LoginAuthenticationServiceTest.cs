using System;
using MedCare.Application.Exceptions;
using MedCare.Application.Services.AuthenticationService;
using MedCare.Commons.Entities;
using MedCare.DB;
using MedCare.DB.Factories;
using MedCare.DB.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedCare.UnitTests
{
    [TestClass]
    public class LoginAuthenticationServiceTest
    {
        #region Attributes and Constructor
        private PatientRepository patientRepository;
        private ProfessionalRepository professionalRepository;
        private IAuthenticationService authenticationService;
        
        [TestInitialize]
        public void Initializate()
        {
            DatabasesConfiguration.RunInitialConfigurationForTests();
            authenticationService = new AuthenticationService(EnumDatabaseTypes.ForTests);
            patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForTests));
            professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(EnumDatabaseTypes.ForTests));
        }
        #endregion

        #region Patient Tests
        [TestMethod]
        public void PatientLoginWithoutAnExistingAccount()
        {
            Assert.ThrowsException<NotFoundUserException>(()
                => authenticationService.ValidateLogin("patientlogin@hotmail.com", "123456"));
        }

        //[TestMethod]
        //public async void PatientLoginWithAnIncorrectPassword()
        //{
        //    Patient patient = new Patient()
        //    {
        //        Email = "patientlogin@hotmail.com",
        //        Password = "123456"
        //    };

        //    await patientRepository.AddNewPatient(patient);
        //    try
        //    {
        //        await Assert.ThrowsExceptionAsync<IncorrectPasswordException>(()
        //        => authenticationService.ValidateLogin("patientlogin@hotmail.com", "654321"));
        //    }
        //    catch (Exception)
        //    {
        //        Assert.IsTrue(false);
        //    }
        //    finally
        //    {
        //        await patientRepository.RemovePatient(patient);
        //    }
        //}

        //[TestMethod]
        //public async void PatientLoginWithAValidPassword()
        //{
        //    Patient patient = new Patient()
        //    {
        //        Email = "patientlogin@hotmail.com",
        //        Password = "123456"
        //    };

        //    try
        //    {
        //        await patientRepository.AddNewPatient(patient);
        //        await authenticationService.ValidateLogin("patientlogin@hotmail.com", "123456");
        //        Assert.IsTrue(true);

        //    }
        //    catch (Exception)
        //    {
        //        Assert.IsTrue(false);
        //        Console.WriteLine("Entity framework error!");
        //    }
        //    finally
        //    {
        //        await patientRepository.RemovePatient(patient);
        //    }
        //}
        //#endregion

        //#region Professional Tests
        //[TestMethod]
        //public async void ProfessionalLoginWithoutAnExistingAccount()
        //{
        //    await Assert.ThrowsExceptionAsync<NotFoundUserException>(()
        //        => authenticationService.ValidateLogin("professionallogin@hotmail.com", "abcdef"));
        //}

        //[TestMethod]
        //public async void ProfessionalLoginWithAnIncorrectPassword()
        //{
        //    Professional professional = new Professional()
        //    {
        //        Email = "professionallogin@hotmail.com",
        //        Password = "abcdef"
        //    };

        //    await professionalRepository.AddNewProfessional(professional);
        //    try
        //    {
        //        await Assert.ThrowsExceptionAsync<IncorrectPasswordException>(()
        //        => authenticationService.ValidateLogin("professionallogin@hotmail.com", "fedcba"));
        //    }
        //    catch (Exception)
        //    {
        //        Assert.IsTrue(false);
        //    }
        //    finally
        //    {
        //        await professionalRepository.RemoveProfessional(professional);
        //    }
        //}

        //[TestMethod]
        //public async void ProfessionalLoginWithAValidPassword()
        //{
        //    Professional professional = new Professional()
        //    {
        //        Email = "professionallogin@hotmail.com",
        //        Password = "abcdef"
        //    };

        //    try
        //    {
        //        await professionalRepository.AddNewProfessional(professional);
        //        Tuple<EnumUserType, int> pResult = await authenticationService.ValidateLogin("professionallogin@hotmail.com", "abcdef");
        //        Assert.IsTrue(true);

        //    }
        //    catch (Exception)
        //    {
        //        Assert.IsTrue(false);
        //        Console.WriteLine("Entity framework error!");
        //    }
        //    finally
        //    {
        //        await professionalRepository.RemoveProfessional(professional);
        //    }
        //}
        #endregion

    }
}
