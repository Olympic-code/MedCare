using MedCare.Commons;
using MedCare.Patient.database;
using MedCare.Professional.databse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MedCare.App.model
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

            using (var professionalDatabase = new ProfessionalDatabse())
            {
                await professionalDatabase.Database.EnsureCreatedAsync();
                var professionalDatabasePath = $"{Path.Combine(ApplicationData.Current.LocalFolder.Path, EnumUsefulStrings.ProfessionalDatabase)}";
            }
        }
    }
}
