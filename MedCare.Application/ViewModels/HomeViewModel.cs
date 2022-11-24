using MedCare.Application.Enums;
using MedCare.Application.Services;
using MedCare.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IScreenControl _screenControl;

        public HomeViewModel(IScreenControl screenControl)
        {
            _screenControl = screenControl;
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
