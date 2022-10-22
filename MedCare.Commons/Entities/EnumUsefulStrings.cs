using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.Commons.Entities
{
    public class EnumUsefulStrings
    {
        private static string _patientDatabase = "patientDatabase.db";
        public static string PatientDatabase { get => _patientDatabase; }

        private static string _professionalDatabase = "professionalDatabase.db";
        public static string ProfessionalDatabase { get => _professionalDatabase; }
    }
}
