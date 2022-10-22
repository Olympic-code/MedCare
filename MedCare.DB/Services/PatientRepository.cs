using MedCare.Commons.Entities;
using MedCare.DB.Databases;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace MedCare.DB.Services
{
    public class PatientRepository : IPatientRepository
    {
        public async Task<bool> AddNewPatient(Patient newPatient)
        {
            using (var patientDatabase = new PatientDatabase())
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
            using (var patientDatabase = new PatientDatabase())
            {
                try
                {
                    List<Patient> allPatients = await GetAllPatients();
                    Patient wantedPatient = (allPatients.Where(p => p.Cpf.Equals(patient.Cpf))).First();
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
            using (var patientDatabase = new PatientDatabase())
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
            using (var patientDatabase = new PatientDatabase())
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
