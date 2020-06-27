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
            var parameter = new NavigationParameters
            {
                { "CurrentIndex", 1 }
            };

            await _navigationService.NavigateAsync($"{PageNameConstants.QuestionPage}", parameter);
        }
    }
}
