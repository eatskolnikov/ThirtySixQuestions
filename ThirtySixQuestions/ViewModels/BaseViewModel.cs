using System;
using Prism.Navigation;

namespace ThirtySixQuestions.ViewModels
{
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
