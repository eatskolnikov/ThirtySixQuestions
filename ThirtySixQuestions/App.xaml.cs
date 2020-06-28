using System;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using ThirtySixQuestions.Constants;
using ThirtySixQuestions.Pages;
using ThirtySixQuestions.Services;
using ThirtySixQuestions.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThirtySixQuestions
{
    public partial class App : PrismApplication
    {

        public App()
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync("MainPage");

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IQuestionsService, QuestionsService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(PageNamesConstants.MainPage);
            containerRegistry.RegisterForNavigation<CardPage, CardPageViewModel>(PageNamesConstants.CardPage);
            containerRegistry.RegisterForNavigation<FinalPage, FinalPageViewModel>(PageNamesConstants.FinalPage);
        }
    }
}
