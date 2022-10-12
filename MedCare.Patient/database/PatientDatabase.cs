using MedCare.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using PatientEntity = MedCare.Commons.entities.Patient;

namespace MedCare.Patient.database
{
    public class PatientDatabase : DbContext
    {
        public DbSet<PatientEntity> Patients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"DataSource={Path.Combine(ApplicationData.Current.LocalFolder.Path, EnumUsefulStrings.PatientDatabase)}");
    }
}
