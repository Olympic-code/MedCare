using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.DB.Services
{
    public interface IProfessionalRepository
    {
        Task<bool> AddNewProfessional(AbstractProfessional newProfessional);
        Task<bool> RemoveProfessional(AbstractProfessional professional);
        Task<bool> GetProfessional(AbstractProfessional professional);
    }
}
