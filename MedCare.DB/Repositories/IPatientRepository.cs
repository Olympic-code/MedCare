using MedCare.Commons.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedCare.DB.Repositories
{
    public interface IPatientRepository : IRepository
    {
        bool AddNewPatient(Patient newPatient);
        bool RemovePatient(Patient patient);
        Patient GetPatient(Patient patient);
        List<Patient> GetAllPatients();
    }
}
