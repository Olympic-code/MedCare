﻿using MedCare.Commons.Entities;
using System;
using System.Threading.Tasks;

namespace MedCare.Application.PopUps.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<Tuple<EnumUserType, int>> ValidateLogin(string email, string password);
        Task ValidateRegistration(EnumUserType userType, string name, string cpf, int age, string contactNumber, string email, string password, string confirmPassword, string profession, string professionalNumber);
    }
}