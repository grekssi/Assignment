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
                new Movie { Title = "Inception", Rating = 3, Image = ImageSource.FromFile("inception.jpg"), Color = Android.Graphics.Color.Red },
            };

            GetMovies();
        }

        public async void GetMovies()
        {
            var movies = await FirebaseConfig.GetMovies();
            Movies = new ObservableCollection<Movie>(movies.Select(x => x.ToModel()));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
