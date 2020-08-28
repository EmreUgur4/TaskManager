using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.WebApp.ViewModels
{
    public class InfoViewModel : NotifyViewModelBase<string>
    {
        public InfoViewModel()
        {
            Header = "Bilgilendirme";
            Title = "İşlem Başarılı";
            IsRedirecting = true;
            RedirectingTimeout = 3000;
        }
    }
}
