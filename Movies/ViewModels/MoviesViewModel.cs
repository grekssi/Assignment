using Movies.Controls;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Movies.ViewModels
{
    public class MoviesViewModel : INotifyPropertyChanged
    {
        public ICommand RedCommand { get; private set; }
        public ICommand BlueCommand { get; private set; }
        public ICommand YellowCommand { get; private set; }


        private Shape _shape;
        public Shape Shape
        {
            get { return _shape; }
            set
            {
                _shape = value;
                OnPropertyChanged(nameof(Shape));
            }
        }

        private int _totalStars = 5;
        public int TotalStars
        {
            get { return _totalStars; }
            set
            {
                _totalStars = value;
                OnPropertyChanged(nameof(TotalStars));
            }
        }

        private double _elementWidth = 40;
        public double ElementWidth
        {
            get { return _elementWidth; }
            set
            {
                if (_elementWidth != value)
                {
                    _elementWidth = value;
                    OnPropertyChanged(nameof(ElementWidth)); 
                }
            }
        }

        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            }
        }

        public MoviesViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            PullMovies();

            RedCommand = new Command(OnRedClicked);
            BlueCommand = new Command(OnBlueClicked);
            YellowCommand = new Command(OnYellowClicked);
        }

        private void OnRedClicked()
        {
            foreach (var movie in Movies)
            {
                movie.Color = "#FF0000";
            }
        }

        private void OnBlueClicked()
        {
            foreach (var movie in Movies)
            {
                movie.Color = "#0000FF";
            }
        }

        private void OnYellowClicked()
        {
            foreach (var movie in Movies)
            {
                movie.Color = "#FFFF00";
            }
        }

        public void PullMovies()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    var newMovies = await FirebaseConfig.GetMovies();
                    var newMovieModels = newMovies.Select(x => x.ToModel()).ToList();

                    // Remove movies that are not in the new list
                    foreach (var movie in Movies.ToList())
                    {
                        if (!newMovieModels.Any(m => m.Id == movie.Id))
                        {
                            Movies.Remove(movie);
                        }
                    }

                    // Add movies that are not in the current list
                    foreach (var movieModel in newMovieModels)
                    {
                        if (!Movies.Any(m => m.Id == movieModel.Id))
                        {
                            Movies.Add(movieModel);
                        }
                    }

                    await Task.Delay(5000);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
