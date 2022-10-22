using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.DB.Services
{
    public interface IPatientRepository
    {
        Task<bool> AddNewPatient(AbstractPatient newPatient);
        Task<bool> RemovePatient(AbstractPatient patient);
        Task<AbstractPatient> GetPatient(AbstractPatient patient);
    }
}
