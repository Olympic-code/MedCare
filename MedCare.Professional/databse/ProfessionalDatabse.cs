using MedCare.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using ProfessionalEntity = MedCare.Commons.entities.Professional;

namespace MedCare.Professional.databse
{
    public class ProfessionalDatabse : DbContext
    {
        public DbSet<ProfessionalEntity> Professionals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"DataSource={Path.Combine(ApplicationData.Current.LocalFolder.Path, EnumUsefulStrings.ProfessionalDatabase)}");
    }
}
