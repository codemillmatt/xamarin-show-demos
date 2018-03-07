using System;
using Xamarin.Forms;
using System.Linq;
using System.Reflection;

namespace Behaviors
{
    public class PickerColorBehavior : Behavior<Picker>
    {

        static readonly BindableProperty ValidValuesProperty =
            BindableProperty.Create(nameof(ValidValues), typeof(string[]), typeof(PickerColorBehavior));

        public string[] ValidValues
        {
            get => (string[])GetValue(ValidValuesProperty);
            set => SetValue(ValidValuesProperty, value);
        }

        static readonly BindableProperty ValidColorProperty =
            BindableProperty.Create(nameof(ValidColor), typeof(Color), typeof(PickerColorBehavior), Color.Default);

        public Color ValidColor
        {
            get => (Color)GetValue(ValidColorProperty);
            set => SetValue(ValidColorProperty, value);
        }

        static readonly BindableProperty InvalidColorProperty =
            BindableProperty.Create(nameof(InvalidColor), typeof(Color), typeof(PickerColorBehavior), Color.Red);

        public Color InvalidColor
        {
            get => (Color)GetValue(InvalidColorProperty);
            set => SetValue(InvalidColorProperty, value);
        }

        static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(PickerColorBehavior), false);

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
            // Bound and cast to a picker
            if (!(sender is Picker bindable))
                return;

            // Make sure the picker is data bound
            if (!(bindable.ItemDisplayBinding is Binding displayBinding))
                return;

            // Get the binding's path
            var displayBindingPath = displayBinding.Path;

            // Use reflection to get the value of the selected item of the picker
            var selectedItem = bindable.SelectedItem.GetType().GetRuntimeProperty(displayBindingPath);
            var selectedText = selectedItem.GetValue(bindable.SelectedItem);

            // Check to see if everything is valid
            if (ValidValues != null && ValidValues.Contains(selectedText))
            {
                IsValid = true;
                bindable.BackgroundColor = Color.Default;
            }
            else
            {
                IsValid = false;
                bindable.BackgroundColor = Color.Salmon;
            }
        }
    }
}
