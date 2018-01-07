using System;
using System.Threading.Tasks;
using MyWeather.ViewModels;
using Xamarin.Forms;

namespace MyWeather.View
{
    public partial class WeatherView : ContentPage
    {
        public WeatherView()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
                Icon = new FileImageSource { File = "tab1.png" };
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (!(BindingContext is WeatherViewModel viewModel))
                return;

            await viewModel.ExecuteGetWeatherCommand();

        }
    }
}

#region Comments

//conditionImage.Opacity = 0;
//conditionImage.Scale = 15;

//conditionLabel.Opacity = 0;
//conditionLabel.TranslationX = 300;

//tempLabel.Opacity = 0;
//tempLabel.RotationX = 0;


//await getWeatherButton.ScaleTo(0);





//conditionImage.ScaleTo(1, 1000, Easing.BounceOut);
//await Task.WhenAll(
//    conditionImage.FadeTo(1, 500),
//    conditionLabel.TranslateTo(0, 0, 500, Easing.SinInOut),
//    conditionLabel.FadeTo(1, 250)
//);

//await Task.WhenAll(
//    tempLabel.FadeTo(1, 100),
//    tempLabel.RotateXTo(720, 1000, Easing.SpringOut)
//);

//await getWeatherButton.ScaleTo(1);

#endregion