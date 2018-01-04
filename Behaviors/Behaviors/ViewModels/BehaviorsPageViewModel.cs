using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace Behaviors
{
    public class BehaviorsPageViewModel : BaseViewModel
    {
        ObservableCollection<string> beardRatings = new ObservableCollection<string>
        {
            "Fair - 0",
            "Good - 1",
            "Cool - 2",
            "Great - 3",
            "Magnificent - 4"
        };

        public ObservableCollection<string> BeardRatings
        { get => beardRatings; }

        string selectedRating;
        public string SelectedBeardRating
        {
            get => selectedRating;
            set => SetProperty(ref selectedRating, value);
        }

        ICommand entryPressCommand;
        public ICommand EntryPressCommand => entryPressCommand ?? (entryPressCommand = new Command<string>(ParseBeardText));

        void ParseBeardText(string input)
        {
            if (input.ToLower().Contains("fair"))
                SelectedBeardRating = BeardRatings[0];
            else if (input.ToLower().Contains("good"))
                SelectedBeardRating = BeardRatings[1];
            else if (input.ToLower().Contains("cool"))
                SelectedBeardRating = BeardRatings[2];
            else if (input.ToLower().Contains("great"))
                SelectedBeardRating = BeardRatings[3];
            else if (input.ToLower().Contains("magnificent"))
                SelectedBeardRating = BeardRatings[4];
        }
    }
}
