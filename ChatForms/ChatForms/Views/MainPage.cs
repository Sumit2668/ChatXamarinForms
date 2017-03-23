using ChatForms.Controls;
using ChatForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatForms.Views
{
    public class MainPage : ContentPage
    {
        private ListView chat;

        private MainViewModel vm => (MainViewModel)BindingContext;

        public MainPage()
        {
            Title = "Chat";

            BindingContext = new MainViewModel();

            chat = new ListView
            {
                HasUnevenRows = true,
                SeparatorVisibility = SeparatorVisibility.None,
                ItemTemplate = new MyDataTemplateSelector(),
                
            };
            chat.ItemSelected += Chat_ItemSelected;
            chat.ItemTapped += Chat_ItemTapped;
            chat.SetBinding(ListView.ItemsSourceProperty, Binding.Create<MainViewModel>(x => x.MessageList));

            var message = new Entry
            {
                Placeholder = "Enter your message...",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            message.SetBinding(Entry.TextProperty, Binding.Create<MainViewModel>(x => x.OutGoingText, BindingMode.TwoWay));

            var btnsend = new Button
            {
                Text = "send"
            };
            btnsend.Clicked += (s, e) =>
            {
                vm.SendCommand.Execute(null);

                var lastItem = chat.ItemsSource.OfType<object>().Last();

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (lastItem != null)
                    {
                        chat.ScrollTo(lastItem, ScrollToPosition.End, true);
                    }
                });

            };

            var send = new StackLayout
            {
                Padding = 16,
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Children =
                {
                    message,btnsend
                }
            };

            Content = new StackLayout
            {
                Children =
                {
                    chat,
                    send
                }
            };
        }

        private void Chat_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            chat.SelectedItem = null;

        }

        private void Chat_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            chat.SelectedItem = null;
        }
    }
}
