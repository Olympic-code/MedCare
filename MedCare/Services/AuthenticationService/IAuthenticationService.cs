using MedCare.Commons.Entities;
using System;
using System.Security;
using System.Threading.Tasks;

namespace MedCare.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<Tuple<EnumUserType, int>> ValidateLogin (string email, String password);

    }
}