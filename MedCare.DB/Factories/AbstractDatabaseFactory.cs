using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.DB.Enums
{
    public abstract class AbstractDatabaseFactory
    {
        public EnumDatabaseTypes type { get; set; }
        public virtual DbContext CreateDatabase() { return null; }
    }
}
