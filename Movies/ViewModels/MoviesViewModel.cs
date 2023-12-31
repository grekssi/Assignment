﻿using Movies.Components;
using Movies.Controls;
using Movies.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Movies.ViewModels
{
    public class MoviesViewModel : INotifyPropertyChanged
    {
        public ICommand SelectedColorCommand { get; private set; }
        public ICommand SelectedShapeCommand { get; private set; }

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

        private double _imageWidth;
        public double ImageWidth
        {
            get { return _imageWidth; }
            set
            {
                if (_imageWidth != value)
                {
                    _imageWidth = value;
                    OnPropertyChanged(nameof(ImageWidth));
                }
            }
        }

        private double _imageHeight;
        public double ImageHeight
        {
            get { return _imageHeight; }
            set
            {
                if (_imageHeight != value)
                {
                    _imageHeight = value;
                    OnPropertyChanged(nameof(ImageHeight));
                }
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

        private string _imageSourceStar;
        public string ImageSourceStar
        {
            get => _imageSourceStar;
            set
            {
                _imageSourceStar = value;
                OnPropertyChanged(nameof(ImageSourceStar));
            }
        }

        private string _imageSourceSquare;
        public string ImageSourceSquare
        {
            get => _imageSourceSquare;
            set
            {
                _imageSourceSquare = value;
                OnPropertyChanged(nameof(ImageSourceSquare));
            }
        }

        private string _imageSourceCircle;
        public string ImageSourceCircle
        {
            get => _imageSourceCircle;
            set
            {
                _imageSourceCircle = value;
                OnPropertyChanged(nameof(ImageSourceCircle));
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

        private ObservableCollection<CustomColorButton> _colors;
        public ObservableCollection<CustomColorButton> Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
                OnPropertyChanged(nameof(Colors));
            }
        }

        private ObservableCollection<CustomShapeButton> _shapes;
        public ObservableCollection<CustomShapeButton> Shapes
        {
            get { return _shapes; }
            set
            {
                _shapes = value;
                OnPropertyChanged(nameof(Shapes));
            }
        }

        private CustomColorButton _selectedColor;
        public CustomColorButton SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }

        private CustomColorButton _selectedShape;
        public CustomColorButton SelectedShape
        {
            get { return _selectedShape; }
            set
            {
                _selectedShape = value;
                OnPropertyChanged(nameof(SelectedShape));
            }
        }


        public MoviesViewModel()
        {
            Colors = new ObservableCollection<CustomColorButton>
            {
                new CustomColorButton{ Color = Color.FromRgb(255,255,0), Text = "Yellow" },
                new CustomColorButton{ Color = Color.FromRgb(0,0,255), Text = "Blue" },
                new CustomColorButton{ Color = Color.FromRgb(0,255,0), Text = "Green" },
                new CustomColorButton{ Color = Color.FromRgb(255,0,0), Text = "Red" },
                new CustomColorButton{ Color = Color.FromRgb(255, 0, 255), Text = "Magenta" }
            };

            Shapes = new ObservableCollection<CustomShapeButton>
            {
                new CustomShapeButton{ Shape = Shape.Circle, VisualSource="Resources/Images/circle_unfilled_vector_maui.xml" },
                new CustomShapeButton{ Shape = Shape.Square, VisualSource="Resources/Images/square_unfilled_vector_maui.xml" },
                new CustomShapeButton{ Shape = Shape.Star, VisualSource="Resources/Images/star_unfilled_vector_maui.xml" }
            };

            SetImageSourceAndDimension();
            Movies = new ObservableCollection<Movie>();
            PullMovies();

            SelectedColorCommand = new Command<CustomColorButton>(OnColorChanged);
            SelectedShapeCommand = new Command<CustomShapeButton>(OnShapeChanged);
        }

        private void SetImageSourceAndDimension()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    ImageWidth = 390;
                    ImageHeight = 500;
                    ImageSourceCircle = "Images/circle.png";
                    ImageSourceSquare = "Images/square.png";
                    ImageSourceStar = "Images/star.png";
                    break;

                case Device.Android:
                    ImageWidth = 420;
                    ImageHeight = 420;

                    ImageSourceCircle = "Resources/Images/circle_unfilled_vector_maui.xml";
                    ImageSourceSquare = "Resources/Images/square_unfilled_vector_maui.xml";
                    ImageSourceStar = "Resources/Images/star_unfilled_vector_maui.xml";
                    break;
            }
        }

        private void OnColorChanged(CustomColorButton button)
        {
            foreach (var movie in Movies)
            {
                movie.Color = button.Color.ToHex();
            }
        }

        private void OnShapeChanged(CustomShapeButton button)
        {
            this.Shape = button.Shape;
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
