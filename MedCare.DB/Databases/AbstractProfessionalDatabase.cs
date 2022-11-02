using MedCare.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.DB.Databases
{
    internal class AbstractProfessionalDatabase : DbContext
    {
        public DbSet<Professional> Professionals { get; set; }
    }
}
