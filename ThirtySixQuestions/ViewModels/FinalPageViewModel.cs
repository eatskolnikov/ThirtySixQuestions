using System;
using System.Windows.Input;
using Prism.Navigation;

namespace ThirtySixQuestions.ViewModels
{
    public class FinalPageViewModel : BaseViewModel
    {
        public ICommand RateCommand { get; set; }

        public FinalPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
