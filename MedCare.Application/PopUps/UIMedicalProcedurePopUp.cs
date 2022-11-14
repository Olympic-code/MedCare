using MedCare.Application.Commands;
using MedCare.Application.Enums;
using MedCare.Commons.Entities;
using MedCare.DB.Factories;
using MedCare.DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MedCare.Application.PopUps
{
    public class UIMedicalProcedurePopUp
    {
        public readonly string Done = $"\bIs Done: ";
        public readonly string Professional = $"\n\bProfessional: ";
        public readonly string Paciente = $"\n\bPacient: ";
        public readonly string Description = $"\n\bDescription: ";
        public readonly string StartDate = $"\n\bStart Date: ";
        public readonly string EndDate = $"\n\bEnd Date: ";
        public MedicalProcedures MedicalProcedure { get; set; }
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }

        public UIMedicalProcedurePopUp()
        {
            RemoveCommand = new RelayCommand(Remove);
            EditCommand = new RelayCommand(Edit);
        }

        public async Task ShowInformationDialog(MedicalProcedures medicalProcedure)
        {
            MedicalProcedure = medicalProcedure;

            ContentDialog medicalProcedureDialog = new ContentDialog
            {

                Title = $"\b{medicalProcedure.Title}".ToUpper(),
                Content = Done + $"{medicalProcedure.Done}" +
                          Professional + $"{medicalProcedure.Professional}" +
                          Paciente + $"{medicalProcedure.Patient}" +
                          Description + $"{medicalProcedure.Description}" +
                          StartDate + $"{medicalProcedure.StartDate}" +
                          EndDate + $"{medicalProcedure.EndDate}",
                PrimaryButtonText = "Remove",
                PrimaryButtonCommand = RemoveCommand,
                SecondaryButtonText = "Edit",
                SecondaryButtonCommand = EditCommand,
                CloseButtonText = "Fechar",
            };
            medicalProcedureDialog.CornerRadius = GetRadiusStyle();
            await medicalProcedureDialog.ShowAsync();
        }


        public void Remove()
        {
            if (SessionManager.SessionType == SessionType.PATIENT)
            {
                PatientRepository patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForImplementation));
            }
          
        }
        public void Edit()
        {

        }
        private CornerRadius GetRadiusStyle()
        {
            return new CornerRadius() { BottomLeft = 10, BottomRight = 10, TopLeft = 10, TopRight = 10 };
        }
    }
}
