using System;
using System.Windows.Input;
using Prism.Navigation;

namespace ThirtySixQuestions.ViewModels
{
    public class CardPageViewModel : BaseViewModel
    {
        public ICommand NextCommand { get; set; }
        public ICommand RestartCommand { get; set; }

        public string BackgroundColor { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int Minutes { get; set; }
        public bool HasTimer { get; set; }
        public bool IsSection { get; set; }
        public int CurrentIndex { get; set; }
        public int TotalCards { get; set; }

        public CardPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            CurrentIndex = parameters.GetValue<int>("CurrentIndex");

        }
    }
}
