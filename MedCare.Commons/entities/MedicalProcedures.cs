﻿using System;

namespace MedCare.Commons.Entities
{
    public class MedicalProcedures
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AbstractPatient Patient { get; set; }
        public AbstractProfessional Professional { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EnumPriority Priority { get; set; }
        public EnumProcedureType Type { get; set; }

    }
}
