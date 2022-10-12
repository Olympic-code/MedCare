using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Commons
{
    public class EnumUsefulStrings
    {
        private static string _patientDatabase = "patientDabase.db";
        public static string PatientDatabase { get => _patientDatabase; }

        private static string _professionalDatabase = "professionalDabase.db";
        public static string ProfessionalDatabase { get => _professionalDatabase; }
    }
}
