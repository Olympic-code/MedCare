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
    public class ProfessionalRepository : IProfessionalRepository
    {
        public async Task<bool> AddNewProfessional(Professional newProfessional)
        {

            using (var professionalDatabase = new ProfessionalDatabase())
            {
                try
                {
                   await professionalDatabase.Professionals.AddAsync(newProfessional);
                   await professionalDatabase.SaveChangesAsync();

                   return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public async Task<Professional> GetProfessional(Professional professional)
        {
            using (var professionalDatabase = new ProfessionalDatabase())
            {
                try
                {
                    List<Professional> allProfessionals = await GetAllProfessionals();
                    Professional wantedProfessional = (allProfessionals.Where(p => p.Cpf.Equals(professional.Cpf))).First();
                    return wantedProfessional;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        public async Task<bool> RemoveProfessional(Professional professional)
        {
            using (var professionalDatabase = new ProfessionalDatabase())
            {
                try
                {
                    Professional wantedProfessional = await GetProfessional(professional);
                    professionalDatabase.Professionals.Remove(wantedProfessional);
                    await professionalDatabase.SaveChangesAsync();

                    return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public async Task<List<Professional>> GetAllProfessionals()
        {
            using (var professionalDatabase = new ProfessionalDatabase())
            {
                try
                {
                    List<Professional> allProfessionals = await professionalDatabase.Professionals.ToListAsync<Professional>();
                    return allProfessionals;
                }
                catch (Exception)
                {
                    return null;
                }
            }

        }
    }
}
