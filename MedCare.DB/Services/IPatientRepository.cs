using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.DB.Services
{
    public interface IPatientRepository
    {
        Task<bool> AddNewPatient(Patient newPatient);
        Task<bool> RemovePatient(Patient patient);
        Task<Patient> GetPatient(Patient patient);
        Task<List<Patient>> GetAllPatients();
    }
}
