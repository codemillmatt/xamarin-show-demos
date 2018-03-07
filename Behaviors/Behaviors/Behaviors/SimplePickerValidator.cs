using System;
using Xamarin.Forms;

namespace Behaviors
{
    public class SimplePickerValidator : Behavior<Picker>
    {
        static readonly BindableProperty ValidValuesProperty =
            BindableProperty.Create(nameof(ValidValues), typeof(string[]), typeof(PickerColorBehavior));

        public string[] ValidValues
        {
            get => (string[])GetValue(ValidValuesProperty);
            set => SetValue(ValidValuesProperty, value);
        }

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


        }
    }
}

//var bindable = (Picker)sender;

//var isValid = bindable.SelectedIndex >= bindable.Items.Count / 2;

//if (isValid)
//    bindable.BackgroundColor = Color.Default;
//else
//bindable.BackgroundColor = Color.Salmon;























#region comments

//public static BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(SimplePickerValidator), false);

//public bool IsValid
//{
//    get => (bool)GetValue(IsValidProperty);
//    private set => SetValue(IsValidProperty, value);
//}

#endregion
