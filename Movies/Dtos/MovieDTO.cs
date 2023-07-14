using Android.Graphics;
using Microsoft.Maui.Controls.Xaml;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Dtos
{
    internal class MovieDTO
    {
        public string Color { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }

        public Models.Movie ToModel()
        {
            return new Models.Movie()
            {
                Color = Android.Graphics.Color.ParseColor(this.Color),
                Title = this.Title,
                Rating = this.Rating,
                Image = ImageSource.FromUri(new Uri(this.Image))
            };
        }
    }
}
