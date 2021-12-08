using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Services
{
    public class SpinnerService : ISpinnerService
    {
		public event Action OnShow;
		public event Action OnHide;


		public void Show()
		{
			OnShow?.Invoke();
		}

		public void Hide()
		{
			OnHide?.Invoke();
		}
	}
}
