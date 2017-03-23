using ChatForms.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatForms.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            MessageList = new ObservableCollection<Message>()
            {
                new Message { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-25)},
                new Message { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-24)},
                new Message { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-23)},
                new Message { Text = "You will love it. Don't miss.", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-23)},
                new Message { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-23)},

                new Message { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-23)},

            };
            OutGoingText = null;
        }

        public RelayCommand SendCommand => new RelayCommand(() =>
        {
            MessageList.Add(new Message { Text = OutGoingText, IsIncoming = false, MessagDateTime = DateTime.Now });
            OutGoingText = null;
        });

        private ObservableCollection<Message> messagesList;

        public ObservableCollection<Message> MessageList
        {
            get { return messagesList; }
            set { messagesList = value; RaisePropertyChanged(); }
        }


        private string outgoingText;

        public string OutGoingText
        {
            get { return outgoingText; }
            set { outgoingText = value; RaisePropertyChanged(); }
        }

        
    }
}
