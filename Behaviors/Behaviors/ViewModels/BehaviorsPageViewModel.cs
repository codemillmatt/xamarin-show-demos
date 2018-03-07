using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace Behaviors
{
    public class BehaviorsPageViewModel : BaseViewModel
    {
        ObservableCollection<Ratings> beardRatings = new ObservableCollection<Ratings>
        {
            new Ratings{ Description="Fair", StarRating = 0 },
            new Ratings{ Description="Good", StarRating = 1 },
            new Ratings{ Description = "Cool", StarRating = 2 },
            new Ratings{ Description = "Great", StarRating = 3 },
            new Ratings{ Description = "Magnificent", StarRating = 4 }
        };

        public ObservableCollection<Ratings> BeardRatings
        { get => beardRatings; }

        Ratings selectedRating;
        public Ratings SelectedBeardRating
        {
            get => selectedRating;
            set => SetProperty(ref selectedRating, value);
        }

        public static string[] ValidRatings = {
            "Good","Magnificent"
        };

        public BehaviorsPageViewModel()
        {
            SelectedBeardRating = BeardRatings[0];
        }

        ICommand entryPressCommand;
        public ICommand EntryPressCommand => entryPressCommand ?? (entryPressCommand =
                                                                   new Command<string>(ParseBeardText));

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
