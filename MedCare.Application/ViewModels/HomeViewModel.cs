using MedCare.Application.Enums;
using MedCare.Application.Services;
using MedCare.Application.ViewModels.Base;
using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IScreenControl _screenControl;

        public ObservableCollection<MedicalProcedures> ExamsList { get; set; }
        public ObservableCollection<MedicalProcedures> ConsultsList { get; set; }

        public HomeViewModel(IScreenControl screenControl)
        {
            _screenControl = screenControl;
            LoadMedicalProceduresResume();
        }

        private void LoadMedicalProceduresResume()
        {
            var typeUser = SessionManager.SessionType;
            LoadMedicalProceduresByUserType(typeUser);
        }

        private void LoadMedicalProceduresByUserType(SessionType userType)
        {
            List<MedicalProcedures> medicalProceduresList;
            if (userType == SessionType.PATIENT)
            {
                var patient = SessionManager.User as Patient;
                medicalProceduresList = patient?.MedicalProcedures;
            }
            else
            {
                var patient = SessionManager.User as Professional;
                medicalProceduresList = patient?.MedicalProcedures;
            }

            if (medicalProceduresList != null)
            {
                foreach (var medicalProcedures in medicalProceduresList)
                {
                    if (medicalProcedures.Type == EnumProcedureType.EXAM && !medicalProcedures.Done && ExamsList.Count < 3)
                    {
                        ExamsList.Add(medicalProcedures);
                    }
                    else if (!medicalProcedures.Done && ExamsList.Count < 3)
                    {
                        ConsultsList.Add(medicalProcedures);
                    }
                }
            }
        }

        public void OpenExamsView()
        {
            _screenControl.NavigateToMedicalProceduresView(MedicalProceduresViewState.EXAM);
        }

        public void OpenAppointmentsView()
        {
            _screenControl.NavigateToMedicalProceduresView(MedicalProceduresViewState.APPOIMENT);
        }
    }
}
