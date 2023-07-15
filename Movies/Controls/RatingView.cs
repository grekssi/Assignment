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

        public static readonly BindableProperty ElementWidthProperty =
           BindableProperty.Create(
               nameof(ElementWidth),
               typeof(double),
               typeof(RatingView),
               default(double));

        public static readonly BindableProperty ColorProperty = 
            BindableProperty.Create(
                nameof(Color),
                typeof(string), 
                typeof(RatingView), 
                default(string));

        public static readonly BindableProperty ShapeProperty =
           BindableProperty.Create(
               nameof(Shape),
               typeof(Shape),
               typeof(RatingView),
               default(Shape));

        public static readonly BindableProperty TotalStarsProperty =
           BindableProperty.Create(
               nameof(TotalStars),
               typeof(int),
               typeof(RatingView),
               default(int));

        public Shape Shape
        {
            get { return (Shape)GetValue(ShapeProperty); }
            set 
            { 
                SetValue(ShapeProperty, value);
            }
        }

        public double ElementWidth
        {
            get { return (double)GetValue(ElementWidthProperty); }
            set { SetValue(ElementWidthProperty, value); }
        }

        public int TotalStars
        {
            get { return (int)GetValue(TotalStarsProperty); }
            set { SetValue(TotalStarsProperty, value); }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public string Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
}
