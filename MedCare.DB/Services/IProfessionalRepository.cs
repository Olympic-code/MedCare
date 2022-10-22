using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.DB.Services
{
    public interface IProfessionalRepository
    {
        Task<bool> AddNewProfessional(Professional newProfessional);
        Task<bool> RemoveProfessional(Professional professional);
        Task<Professional> GetProfessional(Professional professional);
        Task<List<Professional>> GetAllProfessionals();
    }
}
