using Movies.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Movies.ViewModels
{
    public class MoviesViewModel : INotifyPropertyChanged
    {
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
            Movies = new ObservableCollection<Movie>
            {
                //to showcase if connection is not available, or another problem occurs
                new Movie { Title = "Inception", Rating = 3, Image = ImageSource.FromFile("inception.jpg"), Color = Android.Graphics.Color.Red },
            };

            PullMovies(); //polling of movies every 5 seconds and updating the collection
        }

        public async void PullMovies()
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
