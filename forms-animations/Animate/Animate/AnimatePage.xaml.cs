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
            //await translateButton.TranslateTo(100, 0, 4500, Easing.BounceOut);
            //await translateButton.TranslateTo(0, 0);

            try
            {
                ViewExtensions.CancelAnimations(scaleButton);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        async void Scale_Clicked(object sender, System.EventArgs e)
        {
            await scaleButton.ScaleTo(3, 6000);
            await scaleButton.ScaleTo(1, 1000, Easing.SpringOut);
        }

        async void Rotate_Clicked(object sender, System.EventArgs e)
        {
            await rotateButton.RotateTo(180);
            await rotateButton.RotateTo(0, 500, Easing.SpringOut);
        }

        async void Fade_Clicked(object sender, System.EventArgs e)
        {
            await fadeButton.FadeTo(0, 1000, Easing.SinInOut);
        }
    }
}
