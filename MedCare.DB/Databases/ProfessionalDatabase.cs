﻿using MedCare.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Windows.Storage;

namespace MedCare.DB.Databases
{
    internal class ProfessionalDatabase : DbContext
    {
        public DbSet<Professional> Professionals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"DataSource={Path.Combine(ApplicationData.Current.LocalFolder.Path, EnumUsefulStrings.ProfessionalDatabase)}");
    }
}