using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public Android.Graphics.Color Color { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public ImageSource Image { get; set; }
    }

}
