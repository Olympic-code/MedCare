using MedCare.Commons.Entities;
using MedCare.DB.Databases;
using System.IO;
using Windows.Storage;

namespace MedCare.DB
{
    public class DatabasesConfiguration
    {
        public static async void RunInitialConfiguration()
        {
            using (var patientDatabase = new PatientDatabase())
            {
                await patientDatabase.Database.EnsureCreatedAsync();
                var patientDatabasePath = $"{Path.Combine(ApplicationData.Current.LocalFolder.Path, EnumUsefulStrings.PatientDatabase)}";
            }
            using (var professionalDatabase = new ProfessionalDatabase())
            {
                await professionalDatabase.Database.EnsureCreatedAsync();
                var professionalDatabasePath = $"{Path.Combine(ApplicationData.Current.LocalFolder.Path, EnumUsefulStrings.ProfessionalDatabase)}";
            }
        }

        //public static async void RunInitialConfigurationForTests()
        //{
        ////    using (var patientDatabase = new PatientDatabaseTest())
        ////    {
        ////        await patientDatabase.Database.EnsureCreatedAsync();
        ////        var patientDatabasePath = $"{Path.Combine(ApplicationData.Current.LocalFolder.Path, ("[TESTE]" + EnumUsefulStrings.PatientDatabase))}";
        ////    }
        ////    using (var professionalDatabase = new ProfessionalDatabaseTest())
        ////    {
        ////        await professionalDatabase.Database.EnsureCreatedAsync();
        ////        var professionalDatabasePath = $"{Path.Combine(ApplicationData.Current.LocalFolder.Path, ("[TESTE]" + EnumUsefulStrings.ProfessionalDatabase))}";
        ////    }
        //}
    }
}
