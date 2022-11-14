using MedCare.DB.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.DB.Enums
{
    public class ProfessionalDatabaseFactory : AbstractDatabaseFactory
    {
        private readonly EnumDatabaseTypes _databaseType;
        public ProfessionalDatabaseFactory(EnumDatabaseTypes databaseType)
        {
            _databaseType = databaseType;
        }
        public override DbContext CreateDatabase()
        {
            if (_databaseType == EnumDatabaseTypes.ForImplementation)
                return new ProfessionalDatabase();
           
            return null;
        }
    }
}
