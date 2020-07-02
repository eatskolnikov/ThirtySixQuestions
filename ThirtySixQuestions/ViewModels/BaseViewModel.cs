using System;
using Prism;
using Prism.Navigation;
using PropertyChanged;
using ThirtySixQuestions.Constants;
using ThirtySixQuestions.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ThirtySixQuestions.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INavigationAware
    {
        public SocialItem StoreButton { get; set; }
        public SocialItem GithubButton { get; set; }
        public SocialItem YoutubeButton { get; set; }


        protected readonly INavigationService _navigationService;
        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GithubButton = new SocialItem
            {
                Icon = IconConstants.GithubSquare,
                Url = "https://github.com/eatskolnikov/ThirtySixQuestions",
                FollowLinkCommand = new Command<string>(FollowLinkCommandExecute)
            };
            YoutubeButton = new SocialItem
            {
                Icon = IconConstants.Youtube,
                Url = "http://bit.ly/streamelopersub",
                FollowLinkCommand = new Command<string>(FollowLinkCommandExecute)
            };

            if(DeviceInfo.Platform == DevicePlatform.Android)
            { 
                StoreButton = new SocialItem
                {
                    Icon = IconConstants.GooglePlay,
                    Url = "https://play.google.com/store/apps/details?id=io.torib.amon",
                    FollowLinkCommand = new Command<string>(FollowLinkCommandExecute)
                };
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                StoreButton = new SocialItem
                {
                    Icon = IconConstants.AppStore,
                    Url = "https://play.google.com/store/apps/details?id=io.torib.amon",
                    FollowLinkCommand = new Command<string>(FollowLinkCommandExecute)
                };
            }
        }
        public async void FollowLinkCommandExecute(string url)
        {
            await Browser.OpenAsync(url);
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
