using MedCare.DB.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.DB.Enums
{
    public class PatientDatabaseFactory : AbstractDatabaseFactory
    {
        private readonly EnumDatabaseTypes _databaseType;

        public PatientDatabaseFactory(EnumDatabaseTypes databaseType)
        {
            _databaseType = databaseType;
        }
        public override DbContext CreateDatabase() 
        {
            if (_databaseType == EnumDatabaseTypes.ForImplementation)
                return new PatientDatabase();

            return null;
        }
    }
}
