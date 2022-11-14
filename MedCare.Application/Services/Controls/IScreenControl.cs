using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MedCare.Application.Services
{
    public interface IScreenControl
    {
        void NavigateTo(Tuple<EnumUserType, int> userInfomation);
    }
}
