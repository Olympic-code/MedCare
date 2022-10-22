using MedCare.Commons.Entities;
using MedCare.DB.Databases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.DB.Services
{
    public class PatientRepository : IPatientRepository
    {
        public async Task<bool> AddNewPatient(AbstractPatient newPatient)
        {
            using (var patientDatabase = new PatientDatabase())
            {
                try
                {
                    await patientDatabase.AddAsync(newPatient);
                    await patientDatabase.SaveChangesAsync();

                    return true; 
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<AbstractPatient> GetPatient(AbstractPatient patient)
        {
            using (var patientDatabase = new PatientDatabase())
            {
                try
                {
                   AbstractPatient returnPatient = await patientDatabase.Patients.FindAsync(patient);
                   return returnPatient;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<bool> RemovePatient(AbstractPatient patient)
        {
            using (var patientDatabase = new PatientDatabase())
            {
                try
                {
                    patientDatabase.Remove(patient);
                    await patientDatabase.SaveChangesAsync();

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
