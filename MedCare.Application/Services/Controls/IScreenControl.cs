using MedCare.Application.Enums;
using MedCare.Commons.Entities;
using System;

namespace MedCare.Application.Services
{
    public interface IScreenControl
    {
        void NavigateToMainPage(Tuple<EnumUserType, int> userInfomation);
        void NavigateToLoginView();
        void NavigateToRegistrationView();
        void NavigateToMedicalProceduresView(MedicalProceduresViewState typeFrame);
    }
}
