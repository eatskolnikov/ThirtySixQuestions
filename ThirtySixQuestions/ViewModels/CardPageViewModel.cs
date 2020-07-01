using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation;
using Prism.Services;
using ThirtySixQuestions.Constants;
using ThirtySixQuestions.Models;
using ThirtySixQuestions.Resx;
using ThirtySixQuestions.Services;
using Xamarin.Forms;

namespace ThirtySixQuestions.ViewModels
{
    public class CardPageViewModel : BaseViewModel
    {
        private readonly IQuestionsService _questionsService;
        private readonly IPageDialogService _pageDialogService;
        private readonly List<Color> _backgroundColors;

        public CardPageViewModel(INavigationService navigationService, IQuestionsService questionsService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _questionsService = questionsService;

            NextCommand = new Command(NextCommandExecute);
            RestartCommand = new Command(RestartCommandExecute);

            _backgroundColors = new List<Color> {
                (Color)App.Current.Resources["SecondaryDark"],
                (Color)App.Current.Resources["SoftGreen"],
                (Color)App.Current.Resources["SoftRed"],
                (Color)App.Current.Resources["Secondary"],
                (Color)App.Current.Resources["SoftPink"],
            };
            _questionsService.Initialize();
            TimerCounter = new TimerModel
            {
                BgColor = ((Color)App.Current.Resources["DarkGrey"]).ToHex(),//"#CC0000", //"#8251AE",
                Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, 4, 1).Ticks),
                Timespan = new TimeSpan(0, 0, 4, 1)
            };

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                var timespan = TimerCounter.Date - DateTime.Now;
                if(timespan.TotalSeconds > 0)
                {
                    TimerCounter.Timespan = timespan;
                }
                return true;
            });
        }

        public ICommand NextCommand { get; set; }
        public ICommand RestartCommand { get; set; }

        public Color BackgroundColor { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public TimerModel TimerCounter { get; set;}
        public bool IsTimerVisible { get; set; } = false;
        public int TimerOpacity { get; set; } = 0;

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
                if(TimerCounter.Timespan.Minutes > 2)
                {
                    var dialogResult = await _pageDialogService.DisplayAlertAsync("Hold on!", "It is recommended to stay talking at least 2 minutes per question. Are you sure you want to skip now?", "Next question", "Stay a little longer");
                    if(!dialogResult) return;
                }
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
                TimerOpacity = 0;
                IsTimerVisible = false;
            }
            else
            {
                Title = string.Empty;
                Content = QuestionsService.QuestionsTexts[_currentQuestion - 1];
                BackgroundColor = _backgroundColors[_currentQuestion % 4];
                TimerOpacity = 1;
                IsTimerVisible = true;
                TimerCounter.Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, 4, 0).Ticks);
            }
        }
    }
}
