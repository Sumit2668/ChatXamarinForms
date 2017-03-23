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
    public class OutGoingCell : ViewCell
    {
        public OutGoingCell()
        {
            Grid grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            var img = new CircleImage
            {
                Source = "squirrel",
                HeightRequest = 35,
                WidthRequest = 35,
                BorderThickness = 2,
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var blacklabel = new Label
            {
                TextColor = Color.Black,
            };
            blacklabel.SetBinding(Label.TextProperty, Binding.Create<Message>(x => x.Text));

            var frame = new Frame
            {
                Content = blacklabel,
                OutlineColor = Color.Transparent,
                HasShadow = false,
                BackgroundColor = Color.FromHex("#F5F5F5")
            };

            var micro = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.End
            };
            micro.SetBinding(Label.TextProperty, Binding.Create<Message>(x => x.MessagDateTime));


            grid.Children.Add(img, 2, 0);
            grid.Children.Add(frame, 1, 0);
            grid.Children.Add(micro, 1, 1);

            View = grid;
        }
    }
}
