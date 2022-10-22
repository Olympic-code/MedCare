using MedCare.Commons.Entities;
using MedCare.DB.Databases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.DB.Services
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        public async Task<bool> AddNewProfessional(AbstractProfessional newProfessional)
        {

            using (var professionalDatabase = new ProfessionalDatabase())
            {
                try
                {
                
                   await professionalDatabase.Professionals.AddAsync((Professional)newProfessional);
                   await professionalDatabase.SaveChangesAsync();

                   return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public async Task<bool> GetProfessional(AbstractProfessional professional)
        {
            using (var professionalDatabase = new ProfessionalDatabase())
            {
                try
                {
                    await professionalDatabase.Professionals.FindAsync(professional);

                    return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public async Task<bool> RemoveProfessional(AbstractProfessional professional)
        {
            using (var professionalDatabase = new ProfessionalDatabase())
            {
                try
                {
                    professionalDatabase.Remove(professional);
                    await professionalDatabase.SaveChangesAsync();

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
