using System;
using Xamarin.Forms;

namespace Behaviors
{
    public class BeardValidatorBehavior : Behavior<Picker>
    {
        static readonly BindableProperty AcceptableBeardRatingProperty = BindableProperty.Create(nameof(AcceptableBeardRating), typeof(int), typeof(BeardValidatorBehavior), 3);

        public int AcceptableBeardRating
        {
            get => (int)GetValue(AcceptableBeardRatingProperty);
            set => SetValue(AcceptableBeardRatingProperty, value);
        }

        public static BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(BeardValidatorBehavior), false);

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            private set => SetValue(IsValidProperty, value);
        }

        protected override void OnAttachedTo(Picker bindable)
        {
            bindable.SelectedIndexChanged += Bindable_SelectedIndexChanged;

            Bindable_SelectedIndexChanged(bindable, null);
        }

        protected override void OnDetachingFrom(Picker bindable)
        {
            bindable.SelectedIndexChanged -= Bindable_SelectedIndexChanged;
        }

        void Bindable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is Picker bindable))
                return;

            IsValid = bindable.SelectedIndex >= AcceptableBeardRating;

            if (IsValid)
                bindable.BackgroundColor = Color.Default;
            else
                bindable.BackgroundColor = Color.Salmon;

        }
    }
}
