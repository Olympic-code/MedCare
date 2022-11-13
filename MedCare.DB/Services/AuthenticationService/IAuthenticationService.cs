using MedCare.Commons.Entities;
using System;
using System.Threading.Tasks;

namespace MedCare.Application.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<Tuple<EnumUserType, int>> ValidateLogin(string email, String password);
        Task ValidateRegistration(EnumUserType userType, string name, string cpf, int age, int contactNumber,
            string email, String password, String confirmPassword, string profession, string professionalNumber);
    }
}