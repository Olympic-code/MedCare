using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.Commons.Entities
{
    public class EnumUserfulStrings
    {
        private static string _patientDatabase = "patientDabase.db";
        public static string PatientDatabase { get => _patientDatabase; }

        private static string _professionalDatabase = "professionalDabase.db";
        public static string ProfessionalDatabase { get => _professionalDatabase; }
    }
}
