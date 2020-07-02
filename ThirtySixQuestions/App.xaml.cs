﻿using System;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using ThirtySixQuestions.Constants;
using ThirtySixQuestions.Pages;
using ThirtySixQuestions.Services;
using ThirtySixQuestions.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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

            AppCenter.Start("android=2cbf647c-a4d6-413d-8e05-7db31d72daa6;" +
                     "ios=df57b69f-bc5c-4632-b005-0e302e96e12f",
                     typeof(Analytics), typeof(Crashes));

            var result = await NavigationService.NavigateAsync(PageNamesConstants.MainPage);

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
