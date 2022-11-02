using MedCare.Commons.Entities;
using MedCare.DB.Databases;
using MedCare.DB.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedCare.DB.Services
{
    public class PatientRepository : IPatientRepository
    {
        public AbstractDatabaseFactory DatabaseFactory { get; set; }
        public PatientRepository(AbstractDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        public async Task<bool> AddNewPatient(Patient newPatient)
        {
            using (AbstractPatientDatabase patientDatabase = (AbstractPatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    await patientDatabase.Patients.AddAsync((Patient)newPatient);
                    await patientDatabase.SaveChangesAsync();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<Patient> GetPatient(Patient patient)
        {
            using (AbstractPatientDatabase patientDatabase = (AbstractPatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    List<Patient> allPatients = await GetAllPatients();
                    Patient wantedPatient = (allPatients.Where(p => p.Email.Equals(patient.Email))).First();
                    return wantedPatient;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<bool> RemovePatient(Patient patient)
        {
            using (AbstractPatientDatabase patientDatabase = (AbstractPatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    Patient wantedPatient = await GetPatient(patient);
                    patientDatabase.Patients.Remove(wantedPatient);
                    await patientDatabase.SaveChangesAsync();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            using (AbstractPatientDatabase patientDatabase = (AbstractPatientDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    List<Patient> allPatients = await patientDatabase.Patients.ToListAsync<Patient>();
                    return allPatients;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
