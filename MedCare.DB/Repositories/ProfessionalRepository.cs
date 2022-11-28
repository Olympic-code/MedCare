﻿using MedCare.Commons.Entities;
using MedCare.DB.Databases;
using MedCare.DB.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedCare.DB.Repositories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        public AbstractDatabaseFactory DatabaseFactory { get; set; }

        public ProfessionalRepository(AbstractDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        public async Task<bool> AddNewProfessional(Professional newProfessional)
        {
            using (ProfessionalDatabase professionalDatabase = (ProfessionalDatabase)DatabaseFactory.CreateDatabase())
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
            using (ProfessionalDatabase professionalDatabase = (ProfessionalDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    List<Professional> allProfessionals = await GetAllProfessionals();
                    Professional wantedProfessional = (allProfessionals.Where(p => p.Email.Equals(professional.Email))).First();
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
            using (ProfessionalDatabase professionalDatabase = (ProfessionalDatabase)DatabaseFactory.CreateDatabase())
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
            using (ProfessionalDatabase professionalDatabase = (ProfessionalDatabase)DatabaseFactory.CreateDatabase())
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

        public async Task<bool> AddProcedure(Professional professional, MedicalProcedures procedure)
        {
            using (ProfessionalDatabase professionalDatabase = (ProfessionalDatabase)DatabaseFactory.CreateDatabase())
            {
                try
                {
                    Professional wantedProfessional = await GetProfessional(professional);
                    await RemoveProfessional(wantedProfessional);

                    if (wantedProfessional.MedicalAppointments == null)
                        wantedProfessional.MedicalAppointments = new List<MedicalProcedures>();

                    wantedProfessional.MedicalAppointments.Add(procedure);
                    await AddNewProfessional(wantedProfessional);
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