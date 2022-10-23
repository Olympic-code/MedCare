using MedCare.Commons.Entities;
using MedCare.DB.Services;
using MedCare.Exceptions;
using MedCare.Services.AuthenticationServices;
using System;
using System.Security;
using System.Threading.Tasks;

namespace MedCare.Services.AutheticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private IPatientRepository patientRepository;
        private IProfessionalRepository professionalRepository;

        public AuthenticationService()
        {
            this.patientRepository = new PatientRepository();
            this.professionalRepository = new ProfessionalRepository();
        }

        public async Task<Tuple<EnumUserType, int>> ValidateLogin (string email, String password)
        {

            Patient patient = new Patient()
            {
                Email = email,
                Password = password
            };

            Patient patientResult = await patientRepository.GetPatient(patient);
            if(patientResult != null)
            {
                if(patientResult.Password == password)
                {
                    return new Tuple<EnumUserType, int>(EnumUserType.PATIENT, patientResult.Id);
                } else
                {
                    throw new IncorrectPasswordException("Incorrect password");
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
                    return new Tuple<EnumUserType, int>(EnumUserType.PROFESSIONAL, professionalResult.Id);
                } else
                {
                    throw new IncorrectPasswordException("Incorrect password");
                }
            }

            throw new NotFoundUserException("Not found user");
        }

    }
}