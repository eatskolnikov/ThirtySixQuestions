using System;
using System.Windows.Input;

namespace ThirtySixQuestions.Models
{
    public class SocialItem
    {
        public string Icon { get; set; }
        public string Url { get; set; }

        public ICommand FollowLinkCommand { get; set; }
    }
}
