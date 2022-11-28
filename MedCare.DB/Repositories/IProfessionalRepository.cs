﻿using MedCare.Commons.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedCare.DB.Repositories
{
    public interface IProfessionalRepository : IRepository
    {
        Task<bool> AddNewProfessional(Professional newProfessional);
        Task<bool> RemoveProfessional(Professional professional);
        Task<Professional> GetProfessional(Professional professional);
        Task<List<Professional>> GetAllProfessionals();
    }
}