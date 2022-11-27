using MedCare.Commons.Entities;
using MedCare.DB.Databases;
using MedCare.DB.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedCare.DB.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public AbstractDatabaseFactory DatabaseFactory { get; set; }
        public PatientRepository(AbstractDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        public bool AddNewPatient(Patient newPatient)
        {
            using (PatientDatabase patientDatabase = (PatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                     patientDatabase.Patients.Add((Patient)newPatient);
                     patientDatabase.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public Patient GetPatient(Patient patient)
        {
            using (PatientDatabase patientDatabase = (PatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    List<Patient> allPatients = GetAllPatients();
                    Patient wantedPatient = (allPatients.Where(p => p.Email.Equals(patient.Email))).First();

                    return wantedPatient;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool RemovePatient(Patient patient)
        {
            using (PatientDatabase patientDatabase = (PatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    Patient wantedPatient = GetPatient(patient);
                    patientDatabase.Patients.Remove(wantedPatient);
                    patientDatabase.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<Patient> GetAllPatients()
        {
            using (PatientDatabase patientDatabase = (PatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    List<Patient> allPatients = patientDatabase.Patients.Include(p => p.MedicalAppointments).ToList<Patient>();
                    return allPatients;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool AddProcedure(Patient patient, MedicalProcedures procedure)
        {
            using (PatientDatabase patientDatabase = (PatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    Patient wantedPatient = GetPatient(patient);
                    RemovePatient(wantedPatient);

                    if (wantedPatient.MedicalAppointments == null)
                        wantedPatient.MedicalAppointments = new List<MedicalProcedures>();

                    foreach (var currentMedicalProcedure in wantedPatient.MedicalAppointments)
                    {
                        currentMedicalProcedure.Id = 0;
                    }

                    wantedPatient.MedicalAppointments?.Add(procedure);
                    AddNewPatient(wantedPatient);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool GetAllProcedures(Patient patient, MedicalProcedures procedure)
        {
            using (PatientDatabase patientDatabase = (PatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    Patient wantedPatient = GetPatient(patient);
                    RemovePatient(wantedPatient);

                    if (wantedPatient.MedicalAppointments == null)
                        wantedPatient.MedicalAppointments = new List<MedicalProcedures>();

                    wantedPatient.MedicalAppointments?.Add(procedure);
                    AddNewPatient(wantedPatient);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
