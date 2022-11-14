using System;

namespace MedCare.Commons.Entities
{
    public class MedicalProcedures
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Patient Patient { get; set; }
        public Professional Professional { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EnumPriority Priority { get; set; }
        public EnumProcedureType Type { get; set; }
        public bool Done { get; set; }


    }
}
