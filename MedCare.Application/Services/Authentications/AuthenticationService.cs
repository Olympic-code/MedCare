using MedCare.Application.Exceptions;
using MedCare.Commons.Entities;
using MedCare.DB.Enums;
using MedCare.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Attributes and Constructor
        private readonly IPatientRepository patientRepository;
        private readonly IProfessionalRepository professionalRepository;

        public AuthenticationService(EnumDatabaseTypes databaseType)
        {
            this.patientRepository = new PatientRepository(new PatientDatabaseFactory(databaseType));
            this.professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(databaseType));
        }
        #endregion

        #region Validate Login
        public async Task<Tuple<EnumUserType, int>> ValidateLogin(string email, String password)
        {

            Patient patient = new Patient()
            {
                Email = email,
                Password = password
            };

            Patient patientResult = patientRepository.GetPatient(patient);
            if (patientResult != null)
            {
                if (patientResult.Password == password)
                {
                    SessionManager.User = patientResult;
                    SessionManager.SessionType = Enums.SessionType.PATIENT;
                    return new Tuple<EnumUserType, int>(EnumUserType.PATIENT, patientResult.ID);
                }
                else
                {
                    throw new IncorrectPasswordException("Email ou senha inválido");
                }
            }

            Professional professional = new Professional()
            {
                Email = email,
                Password = password
            };

            Professional professionalResult = await professionalRepository.GetProfessional(professional);
            if (professionalResult != null)
            {
                if (professionalResult.Password == password)
                {
                    SessionManager.User = professionalResult;
                    SessionManager.SessionType = Enums.SessionType.PROFESSIONAL;
                    return new Tuple<EnumUserType, int>(EnumUserType.PROFESSIONAL, professionalResult.ID);
                }
                else
                {
                    throw new IncorrectPasswordException("Email ou senha inválido");
                }
            }

            throw new NotFoundUserException("Email ou senha inválido");
        }
        #endregion

        #region Validate Registration
        public Task ValidateRegistration(EnumUserType userType, string name, string cpf, int age, string contactNumber,
            string email, String password, String confirmPassword, string profession, string professionalNumber)
        {
            if (password != confirmPassword)
            {
                throw new PasswordsAreNotEqualsException("Passwords are not equals");
            }

            if (userType == EnumUserType.PATIENT)
            {
                return PatientRegistration(name, cpf, age, contactNumber, email, password);
            }
            else
            {
                return ProfessionalRegistration(name, cpf, age, contactNumber, email, password, profession, professionalNumber);
            }

        }

        private Task PatientRegistration(string name, string cpf, int age, string contactNumber, string email, String password)
        {
            Patient patient = new Patient()
            {
                Name = name,
                Cpf = cpf,
                Age = age,
                PhoneNumber = contactNumber,
                Email = email,
                Password = password
            };

            Patient patientResult = patientRepository.GetPatient(patient);
            if (patientResult != null)
            {
                throw new UserAlreadyExistsException("E-mail linked to an existing account");
            }

            patientRepository.AddNewPatient(patient);
            return Task.CompletedTask;
        }

        private async Task ProfessionalRegistration(string name, string cpf, int age, string contactNumber, string email,
            String password, string profession, string professionalNumber)
        {
            Professional professional = new Professional()
            {
                Email = email,
                Password = password
            };

            Professional professionalResult = await professionalRepository.GetProfessional(professional);
            if (professionalResult != null)
            {
                throw new UserAlreadyExistsException("E-mail linked to an existing account");
            }

            await professionalRepository.AddNewProfessional(professional);
        }
        #endregion

    }
}
