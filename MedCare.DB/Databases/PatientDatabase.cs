using MedCare.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Windows.Storage;

namespace MedCare.DB.Databases
{
    internal class PatientDatabase : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=localhost;port=3306;database=medcaredb;uid=root;password=1234");
    }
}
