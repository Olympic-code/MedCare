using MedCare.Application.PopUps;
using MedCare.Commons.Entities;
using MedCare.DB;
using MedCare.DB.Enums;
using MedCare.DB.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MedCare.Application.Usercontrols
{
    public sealed partial class AddMedicalProcedureControl : UserControl
    {
        #region props
        public string Procedure_Title { get; set; }
        public string ProfessionalEmail { get; set; }
        public string PatientEmail { get; set; }
        public string ProcedureDescription { get; set; }
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now;
        public int ComboBoxPriorityIndex { get; set; }
        public int ComboBoxTypeIndex { get; set; }
        public bool IsDone { get; set; }
        public UIInformationPopUp InformationPopUp { get; set; }
        public Visibility Visibility
        {
            get { return (Visibility)GetValue(VisibilityProperty); }
            set { SetValue(VisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Visibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibilityProperty =
            DependencyProperty.Register("Visibility", typeof(Visibility), typeof(AddMedicalProcedureControl), new PropertyMetadata(Visibility.Collapsed));

        #endregion

        public AddMedicalProcedureControl()
        {
            InformationPopUp = new UIInformationPopUp(SetVisibilityCollapsed) { ScreenName = "Add Medical Procedure" };
            this.InitializeComponent();
            Procedure_Title = ProcedureTitleTextBox.Text;
            ProfessionalEmail = ProfessionalEmailTextBox.Text;
            PatientEmail = PatientEmailTextBox.Text;
            ProcedureDescription = DecriptionTextBox.Text;
        }

        #region methods
        private void AddNewAppoimentBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfessionalRepository professionalRepository = new ProfessionalRepository(new ProfessionalDatabaseFactory(EnumDatabaseTypes.ForImplementation));
            PatientRepository patientRepository = new PatientRepository(new PatientDatabaseFactory(EnumDatabaseTypes.ForImplementation));
            DatabasesConfiguration.RunInitialConfiguration();
            var listProfessionals = professionalRepository.GetAllProfessionals().Result;
            Professional professional = professionalRepository.GetProfessional(new Professional() { Email = ProfessionalEmail }).Result;
            Patient patient = patientRepository.GetPatient(new Patient() { Email = PatientEmail }).Result;

            AbstractUser currentUser = SessionManager.User;

            MedicalProcedures newMedicalProcedure = new MedicalProcedures()
            {
                Title = Procedure_Title,
                Description = ProcedureDescription,
                StartDate = StartDate.DateTime,
                EndDate = EndDate.DateTime,
                Done = IsDone
            };

            newMedicalProcedure.Professional = professional;
            newMedicalProcedure.Patient = patient;

            switch (ComboBoxPriorityIndex)
            {
                case 0:
                    newMedicalProcedure.Priority = EnumPriority.URGENT;
                    break;
                case 1:
                    newMedicalProcedure.Priority = EnumPriority.HIGH;
                    break;
                case 2:
                    newMedicalProcedure.Priority = EnumPriority.NORMAL;
                    break;
            }

            if (SessionManager.SessionType == Enums.SessionType.PROFESSIONAL)
                showPopUp(professionalRepository.AddProcedure((Professional)currentUser, newMedicalProcedure).Result);
            else
                showPopUp(patientRepository.AddProcedure((Patient)currentUser, newMedicalProcedure).Result);

            showPopUp(true);
        }

        private void showPopUp(bool wasSuccessful)
        {
            if (wasSuccessful)
                InformationPopUp.showSuccessfulMessage();
            else
                InformationPopUp.showNotSuccessfulMessage();
        }

        public void SetVisibilityCollapsed()
        {
            Visibility = Visibility.Collapsed;
        }
        #endregion

    }
}
