using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace VictorinaUniversal.ViewModels
{
    public class MainViewModel
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
