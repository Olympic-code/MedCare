using MedCare.Application.Commands;
using MedCare.Application.Enums;
using MedCare.Application.PopUps;
using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
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
        public List<MedicalProcedures> MedicalProcedures { get; set; }
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
            MedicalProcedures = new List<MedicalProcedures>();

            for (int i = 0; i < 10; i++)
            {
                MedicalProcedures.Add(new Commons.Entities.MedicalProcedures() { Title = "Medical " + i, Description = "teste " + i, StartDate = DateTime.Now, EndDate = DateTime.Now });
            }
            State = state;
            UpadateViewElementsVisibility();
        }
        #region Methods
        private async Task ListView_SelectionChangedAsync()
        {
           await UIMedicalProcedurePopUp.ShowInformationDialog(SelectedMedicalProcedure);
        }

        public void UpadateViewElementsVisibility()
        {
            if (State == MedicalProceduresViewState.APPOIMENT)
            {
                SetAllAppoimentsElementsVisible();
                SetAllExamsElementsCollapsed();
                return;
            }
            SetAllExamsElementsVisible();
            SetAllAppoimentsElementsCollapsed();
        }
        #endregion

        #region Visibilities
        public Visibility AppoimentsFrameTitleVisibility { get; set; }
        public Visibility ExamsFrameTitleVisibility { get; set; }
        public Visibility CompleteAppoimentsFrameTitleVisibility { get; set; }
        public Visibility CompleteExamsFrameTitleVisibility { get; set; }
        public Visibility IncompleteAppoimentsFrameTitleVisibility { get; set; }
        public Visibility IncompleteExamsFrameTitleVisibility { get; set; }

        private void SetAllExamsElementsCollapsed()
        {
            ExamsFrameTitleVisibility = Visibility.Collapsed;
            CompleteExamsFrameTitleVisibility = Visibility.Collapsed;
            IncompleteExamsFrameTitleVisibility = Visibility.Collapsed;
        }
        private void SetAllExamsElementsVisible()
        {
            ExamsFrameTitleVisibility = Visibility.Visible;
            CompleteExamsFrameTitleVisibility = Visibility.Visible;
            IncompleteExamsFrameTitleVisibility = Visibility.Visible;
        }

        private void SetAllAppoimentsElementsVisible()
        {
            AppoimentsFrameTitleVisibility = Visibility.Visible;
            CompleteAppoimentsFrameTitleVisibility = Visibility.Visible;
            IncompleteAppoimentsFrameTitleVisibility = Visibility.Visible;
        }

        private void SetAllAppoimentsElementsCollapsed()
        {
            AppoimentsFrameTitleVisibility = Visibility.Collapsed;
            CompleteAppoimentsFrameTitleVisibility = Visibility.Collapsed;
            IncompleteAppoimentsFrameTitleVisibility = Visibility.Collapsed;
        }
        #endregion

    }
}
