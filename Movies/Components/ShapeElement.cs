using Movies.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Components
{
    public class ShapeElement : ImageButton
    {
        public static readonly BindableProperty ShapeProperty =
            BindableProperty.Create(nameof(Shape), typeof(Shape), typeof(ShapeElement), Shape.Star);

        public Shape Shape
        {
            get { return (Shape)GetValue(ShapeProperty); }
            set { SetValue(ShapeProperty, value); }
        }

        public ShapeElement()
        {
        }
    }
}
