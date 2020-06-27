using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation;
using ThirtySixQuestions.Resx;
using ThirtySixQuestions.Services;
using Xamarin.Forms;

namespace ThirtySixQuestions.ViewModels
{
    public class CardPageViewModel : BaseViewModel
    {
        private readonly IQuestionsService _questionsService;
        private readonly List<Color> _backgroundColors;

        public CardPageViewModel(INavigationService navigationService, IQuestionsService questionsService) : base(navigationService)
        {
            NextCommand = new Command(NextCommandExecute);
            RestartCommand = new Command(RestartCommandExecute);

            _backgroundColors = new List<Color> {
                (Color)App.Current.Resources["Primary"],
                (Color)App.Current.Resources["PrimaryDark"],
                (Color)App.Current.Resources["Secondary"],
                (Color)App.Current.Resources["SecondaryDark"],
                Color.Black
            };

            _questionsService = questionsService;
            _questionsService.Initialize();
        }

        public ICommand NextCommand { get; set; }
        public ICommand RestartCommand { get; set; }

        public Color BackgroundColor { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        /*
        public int Minutes { get; set; }
        public bool HasTimer { get; set; }
        */
        private int _currentQuestion;
        private int _currentSet;
        private bool _isSet;
        

        public async void NextCommandExecute()
        {
            if(_isSet)
            {
                _currentQuestion++;
                _isSet = false;
            }
            else
            {
                if((_currentQuestion%12) == 0)
                {
                    _isSet = true;
                    _currentSet++;
                }
                _currentQuestion++;
            }
            if(_currentSet < 4 && _currentQuestion < 36)
            {
                RefreshCard();
            }
            else
            {
                await _navigationService.NavigateAsync($"{PageNamesConstants.FinalPage}");
            }
        }

        public async void RestartCommandExecute()
        {
            await _navigationService.NavigateAsync($"{PageNamesConstants.MainPage}");
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _currentQuestion = parameters.GetValue<int>(ParameterNamesConstants.CurrentQuestion);
            _currentSet = parameters.GetValue<int>(ParameterNamesConstants.CurrentSet);
            _isSet = parameters.GetValue<bool>(ParameterNamesConstants.IsSet);
            RefreshCard();

        }

        private void RefreshCard()
        {
            if (_isSet)
            {
                Title = QuestionsService.SetsTexts[_currentSet - 1];
                Content = string.Empty;
                BackgroundColor = _backgroundColors[4];
            }
            else
            {
                Title = string.Empty;
                Content = QuestionsService.QuestionsTexts[_currentQuestion - 1];
                BackgroundColor = _backgroundColors[_currentQuestion % 4];
            }
        }
    }
}
