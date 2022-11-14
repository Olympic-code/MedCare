using MedCare.Commons.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedCare.DB.Repositories
{
    public interface IPatientRepository : IRepository
    {
        Task<bool> AddNewPatient(Patient newPatient);
        Task<bool> RemovePatient(Patient patient);
        Task<Patient> GetPatient(Patient patient);
        Task<List<Patient>> GetAllPatients();
    }
}
