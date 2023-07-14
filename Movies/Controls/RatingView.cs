using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Controls
{
    public class RatingView : View
    {
        public static readonly BindableProperty ValueProperty = 
            BindableProperty.Create(
                nameof(Value), 
                typeof(int), 
                typeof(RatingView),
                default(int));

        public static readonly BindableProperty ColorProperty = 
            BindableProperty.Create(
                nameof(Color),
                typeof(Android.Graphics.Color), 
                typeof(RatingView), 
                default(Android.Graphics.Color));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public Android.Graphics.Color Color
        {
            get { return (Android.Graphics.Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
}
