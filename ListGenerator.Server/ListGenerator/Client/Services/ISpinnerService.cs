using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Services
{
    public interface ISpinnerService
    {
        event Action OnShow;
        event Action OnHide;
        void Show();
        void Hide();
    }
}
