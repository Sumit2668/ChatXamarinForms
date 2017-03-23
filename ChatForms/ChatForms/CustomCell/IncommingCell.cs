using ChatForms.Model;
using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatForms.CustomCell
{
    public class IncommingCell : ViewCell
    {
        public IncommingCell()
        {

            Grid grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            var image = new CircleImage
            {
                WidthRequest = 35,
                HeightRequest = 35,
                BorderThickness = 2,
                BorderColor = Color.FromHex("#03A9F4"),
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = "baboon"
            };
            

            var whitelabel = new Label()
            {
                TextColor = Color.White
            };
            whitelabel.SetBinding(Label.TextProperty, Binding.Create<Message>(x => x.Text));
            
            var frame = new Frame
            {
                OutlineColor = Color.Transparent,
                HasShadow = false,
                BackgroundColor = Color.FromHex("#03A9F4"),
                Content = whitelabel
            };

            var micro = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = Color.Gray
            };
            micro.SetBinding(Label.TextProperty, Binding.Create<Message>(x => x.MessagDateTime));


            grid.Children.Add(image, 0, 0);
            grid.Children.Add(frame, 1, 0);
            grid.Children.Add(micro, 1, 1);

            View = grid;

        }
    }
}
