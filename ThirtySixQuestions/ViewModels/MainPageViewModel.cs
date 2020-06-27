using System;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace ThirtySixQuestions.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand StartCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            StartCommand = new Command(StartCommandExecute);
        }

        public async void StartCommandExecute()
        {
            var parameters = new NavigationParameters
            {
                { ParameterNamesConstants.CurrentQuestion, 1 },
                { ParameterNamesConstants.CurrentSet, 1 },
                { ParameterNamesConstants.IsSet, true }
            };

            await _navigationService.NavigateAsync($"{PageNamesConstants.CardPage}", parameters);
        }
    }
}
