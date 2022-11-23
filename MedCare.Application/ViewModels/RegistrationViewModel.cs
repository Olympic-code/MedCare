using MedCare.Application.Commands;
using MedCare.Application.PopUps;
using MedCare.Application.Services;
using MedCare.Commons.Entities;
using MedCare.DB.Enums;
using MedCare.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.ViewModels
{
    public class RegistrationViewModel
    {
        private readonly IScreenControl _screenControl;

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Age { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Job { get; set; }
        public string JobCode { get; set; }
        public int RegisterType { get; set; }
        public UIInformationPopUp InformationPopUp { get; set; }
        public RelayCommand RegisterCommand { get; set; }

        public RegistrationViewModel(IScreenControl screenControl)
        {
            _screenControl = screenControl;
            RegisterCommand = new RelayCommand(Register);
            InformationPopUp = new UIInformationPopUp(OpenLoginScreen) { ScreenName = "Registration" };
        }

        public void Register()
        {
            if (RegisterType == 0)
                RegisterProfessional();
            else
                Registerpatient();
        }

        private void Registerpatient()
        {
            ProfessionalRepository professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(EnumDatabaseTypes.ForImplementation));
            Professional newProfessional = new Professional();
            newProfessional.Name = Name;
            newProfessional.Email = Email;
            newProfessional.Age = int.Parse(Age);
            newProfessional.Password = Password;
            newProfessional.PhoneNumber = CellPhone;
            newProfessional.ProfessionalRegister = JobCode;

            bool wasSuccessful = professionalRepository.AddNewProfessional(newProfessional).Result;

            if (wasSuccessful)
                InformationPopUp.showSuccessfulMessage();
            else
                InformationPopUp.showNotSuccessfulMessage();
        }

        private void RegisterProfessional()
        {
            PatientRepository patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForImplementation));
            Patient newPatient = new Patient();
            newPatient.Name = Name;
            newPatient.Email = Email;
            newPatient.Age = int.Parse(Age);
            newPatient.Password = Password;
            newPatient.PhoneNumber = CellPhone;
            bool wasSuccessful = patientRepository.AddNewPatient(newPatient).Result;

            if (wasSuccessful)
                InformationPopUp.showSuccessfulMessage();
            else
                InformationPopUp.showNotSuccessfulMessage();
        }

        public void OpenLoginScreen()
        {
            _screenControl.NavigateToLoginView();
        }
    }
}
