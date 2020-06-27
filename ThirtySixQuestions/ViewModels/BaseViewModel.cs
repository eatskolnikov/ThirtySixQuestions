using System;
using Prism.Navigation;
using PropertyChanged;

namespace ThirtySixQuestions.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INavigationAware
    {
        protected readonly INavigationService _navigationService;
        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
