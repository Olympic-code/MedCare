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
    public class ProfessionalRepositoryTest
    {
        #region Attributes and Constructor
        private ProfessionalRepository professionalRepository;

        public ProfessionalRepositoryTest()
        {
            DatabasesConfiguration.RunInitialConfigurationForTests();
            professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(EnumDatabaseTypes.ForTests));
        }
        #endregion

        #region Create Users Tests
        [Fact]
        public async void AddingNewprofessional()
        {
            string email = "professional@gmail.com";
            Professional professional = new Professional() { Email = email };

            try
            {
                await professionalRepository.AddNewProfessional(professional);
                Professional professionalLocated = await professionalRepository.GetProfessional(professional);

                Assert.Equal(email, professionalLocated.Email);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                await professionalRepository.RemoveProfessional(professional);
            }
        }

        [Fact]
        public async void AddingNewprofessionalWithCredentialAlredyExists()
        {
            string email = "professional@gmail.com";
            Professional professional = new Professional() { Email = email };
            Professional professionalTwo = new Professional() { Email = email };

            try
            {
                await professionalRepository.AddNewProfessional(professional);
                await professionalRepository.AddNewProfessional(professionalTwo);

                Assert.True(false);

            }
            catch (Exception e)
            {
                Assert.True(true);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                await professionalRepository.RemoveProfessional(professional);
                await professionalRepository.RemoveProfessional(professionalTwo);
            }
        }
        #endregion

        #region Get User Tests
        [Fact]
        public async void GetAnExistingprofessional()
        {
            string email = "professional@gmail.com";
            Professional professional = new Professional() { Email = email };

            try
            {
                await professionalRepository.AddNewProfessional(professional);
                Professional professionalLocated = await professionalRepository.GetProfessional(professional);

                Assert.Equal(email, professionalLocated.Email);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
            finally
            {
                await professionalRepository.RemoveProfessional(professional);
            }
        }

        [Fact]
        public async void GetAnUnexistingprofessional()
        {
            string email = "professional@gmail.com";
            Professional professional = new Professional() { Email = email };
            try
            {
                Professional professionalLocated = await professionalRepository.GetProfessional(professional);

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
        public async void GetAllprofessionalsWithEmptyDatabase()
        {

            try
            {
                List<Professional> allprofessionalsInDatabase = await professionalRepository.GetAllProfessionals();

                Assert.Empty(allprofessionalsInDatabase);

            }
            catch (Exception)
            {
                Assert.True(false);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void GetAllprofessionals()
        {

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Professional professional = new Professional() { Email = "professional" + i + "@gmail.com" };
                    await professionalRepository.AddNewProfessional(professional);
                }

                List<Professional> allprofessionalsInDatabase = await professionalRepository.GetAllProfessionals();

                Assert.NotEmpty(allprofessionalsInDatabase);
                Assert.Equal(10, allprofessionalsInDatabase.Count);
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
                    Professional professional = new Professional() { Email = "professional" + i + "@gmail.com" };
                    await professionalRepository.RemoveProfessional(professional);
                }
            }
        }
        #endregion

        #region Delete Users Tests
        [Fact]
        public async void RemovingExistingprofessional()
        {

            try
            {
                string email = "professional@gmail.com";
                Professional professional = new Professional() { Email = email };
                await professionalRepository.AddNewProfessional(professional);
                await professionalRepository.RemoveProfessional(professional);
                Professional professionalLocated = await professionalRepository.GetProfessional(professional);

                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
                Console.WriteLine("Entity framework error!");
            }
        }

        [Fact]
        public async void RemovingUnexistingprofessional()
        {

            try
            {
                string email = "professional@gmail.com";
                Professional professional = new Professional() { Email = email };
                await professionalRepository.RemoveProfessional(professional);

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
