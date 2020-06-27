using System;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using ThirtySixQuestions.Pages;
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
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(PageNameConstants.MainPage);
            containerRegistry.RegisterForNavigation<CardPage, CardPageViewModel>(PageNameConstants.CardPage);
        }
    }

    public class PageNameConstants
    {
        public static string MainPage => "MainPage";
        public static string CardPage => "CardPage";
    }
}
