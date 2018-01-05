using System;
using Xamarin.Forms;

namespace Behaviors
{
    public class SimplePickerValidator : Behavior<Picker>
    {
        public static BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(SimplePickerValidator), false);

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            private set => SetValue(IsValidProperty, value);
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
            if (!(sender is Picker bindable))
                return;

            IsValid = bindable.SelectedIndex >= bindable.Items.Count / 2;

            if (IsValid)
                bindable.BackgroundColor = Color.Default;
            else
                bindable.BackgroundColor = Color.Salmon;

        }
    }
}
