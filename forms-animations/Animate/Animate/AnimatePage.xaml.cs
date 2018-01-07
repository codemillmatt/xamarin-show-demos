using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Animate
{
    public partial class AnimatePage : ContentPage
    {
        public AnimatePage()
        {
            InitializeComponent();
        }

        async void Translate_Clicked(object sender, System.EventArgs e)
        {
            await translateButton.TranslateTo(0, -100);
            await translateButton.TranslateTo(100, -100);
            await translateButton.TranslateTo(100, 0);
            await translateButton.TranslateTo(0, 0);
        }

        async void Scale_Clicked(object sender, System.EventArgs e)
        {
            await scaleButton.ScaleTo(2);
            await scaleButton.ScaleTo(1, 500, Easing.BounceOut);
        }

        async void Rotate_Clicked(object sender, System.EventArgs e)
        {
            await rotateButton.RotateTo(180);
            await rotateButton.RotateTo(0, 500, Easing.SpringOut);
        }

        async void Fade_Clicked(object sender, System.EventArgs e)
        {
            await fadeButton.FadeTo(0);
            await fadeButton.FadeTo(1, 1000);
        }
    }
}
