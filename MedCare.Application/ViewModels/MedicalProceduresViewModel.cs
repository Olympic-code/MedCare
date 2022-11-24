using MedCare.Application.Commands;
using MedCare.Application.Enums;
using MedCare.Application.PopUps;
using MedCare.Commons.Entities;
using MedCare.DB.Enums;
using MedCare.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MedCare.Application.ViewModels
{
    public class MedicalProceduresViewModel : INotifyPropertyChanged
    {
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        public MedicalProceduresViewState State { get; set; }
        public EnumProcedureType ProcedureType { get; set; }
        public ObservableCollection<MedicalProcedures> MedicalProceduresDone { get; set; } = new ObservableCollection<MedicalProcedures>();
        public ObservableCollection<MedicalProcedures> MedicalProceduresNotDone { get; set; } = new ObservableCollection<MedicalProcedures>();
        public UIMedicalProcedurePopUp UIMedicalProcedurePopUp { get; set; }

        private MedicalProcedures _selectedMedicalProcedure;

        public MedicalProcedures SelectedMedicalProcedure
        {
            get { return _selectedMedicalProcedure; }
            set
            {
                _selectedMedicalProcedure = value;
                ListView_SelectionChangedAsync();
            }
        }

        #endregion

        public MedicalProceduresViewModel(MedicalProceduresViewState state)
        {
            UIMedicalProcedurePopUp = new UIMedicalProcedurePopUp();
            if (state == MedicalProceduresViewState.APPOIMENT)
            {
                ProcedureType = EnumProcedureType.APPOINTMENT;
            }
            else
            {
                ProcedureType = EnumProcedureType.EXAM;
            }
            UpdateList();
        }

        #region Methods
        private async Task ListView_SelectionChangedAsync()
        {
           await UIMedicalProcedurePopUp.ShowInformationDialog(SelectedMedicalProcedure);
        }

        public void UpdateList()
        {
            if (SessionManager.User != null)
            {
                if (SessionManager.SessionType == SessionType.PATIENT)
                {
                    PatientRepository patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForImplementation));
                    Patient currentPatient = patientRepository.GetPatient((Patient)SessionManager.User).Result;
                    if (currentPatient.MedicalAppointments != null)
                    {
                        MedicalProceduresDone = new ObservableCollection<MedicalProcedures>(currentPatient.MedicalAppointments.Where(m => m.Done == true && m.Type == ProcedureType));
                        MedicalProceduresNotDone = new ObservableCollection<MedicalProcedures>(currentPatient.MedicalAppointments.Where(m => m.Done == false && m.Type == ProcedureType));
                    }
                   
                }
                else
                {
                    ProfessionalRepository professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(EnumDatabaseTypes.ForImplementation));
                    Professional currentProfessional = professionalRepository.GetProfessional((Professional)SessionManager.User).Result;

                    if (currentProfessional.MedicalAppointments != null)
                    {
                        MedicalProceduresDone = new ObservableCollection<MedicalProcedures>(currentProfessional.MedicalAppointments.Where(m => m.Done == true && m.Type == ProcedureType));
                        MedicalProceduresNotDone = new ObservableCollection<MedicalProcedures>(currentProfessional.MedicalAppointments.Where(m => m.Done == false && m.Type == ProcedureType));
                    }
                }
            }
            //else
            //{
            //    for (int i = 0; i < 1; i++)
            //    {
            //        MedicalProceduresDone.Add(new Commons.Entities.MedicalProcedures() { Title = "Medical " + i, Description = "teste " + i, StartDate = DateTime.Now, EndDate = DateTime.Now });
            //        MedicalProceduresNotDone.Add(new Commons.Entities.MedicalProcedures() { Title = "Medical " + i, Description = "teste " + i, StartDate = DateTime.Now, EndDate = DateTime.Now });
            //    }
            //}
        }
        #endregion

    }
}
