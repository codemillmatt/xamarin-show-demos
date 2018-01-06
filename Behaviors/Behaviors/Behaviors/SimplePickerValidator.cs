using System;
using Xamarin.Forms;

namespace Behaviors
{
    public class SimplePickerValidator : Behavior<Picker>
    {
        protected override void OnAttachedTo(Picker bindable)
        {
            bindable.SelectedIndexChanged += Bindable_SelectedIndexChanged;
        }

        protected override void OnDetachingFrom(Picker bindable)
        {
            bindable.SelectedIndexChanged -= Bindable_SelectedIndexChanged;
        }

        void Bindable_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;

            var isValid = picker.SelectedIndex >= picker.Items.Count / 2;

            if (isValid)
                picker.BackgroundColor = Color.Default;
            else
                picker.BackgroundColor = Color.Salmon;
        }
    }
}

#region comments

//public static BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(SimplePickerValidator), false);

//public bool IsValid
//{
//    get => (bool)GetValue(IsValidProperty);
//    private set => SetValue(IsValidProperty, value);
//}

#endregion
