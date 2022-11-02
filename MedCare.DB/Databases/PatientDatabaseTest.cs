using MedCare.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage;

namespace MedCare.DB.Databases
{
    internal class PatientDatabaseTest : AbstractPatientDatabase
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"DataSource={Path.Combine(ApplicationData.Current.LocalFolder.Path, ( "[TESTE]"+ EnumUsefulStrings.PatientDatabase))}");
    }
}
