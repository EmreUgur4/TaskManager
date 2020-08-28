using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities.Messages;

namespace TaskManager.WebApp.ViewModels
{
    public class ErrorViewModel : NotifyViewModelBase<ErrorMessageObj>
    {
        public ErrorViewModel()
        {
            Header = "Hata";
            Title = "İşlem Başarısız";
            IsRedirecting = true;
            RedirectingTimeout = 100;
        }
    }
}
