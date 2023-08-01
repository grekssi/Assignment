using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Components
{
    public class ColorElement : Button
    {
        public static readonly BindableProperty ElementColorProperty =
            BindableProperty.Create(nameof(ElementColor), typeof(Color), typeof(ColorElement), Color.FromRgb(20, 5, 10), propertyChanged: OnElementColorChanged);

        public static readonly BindableProperty ElementTextProperty =
            BindableProperty.Create(nameof(ElementText), typeof(string), typeof(ColorElement), string.Empty, propertyChanged: OnElementTextChanged);

        public Color ElementColor
        {
            get { return (Color)GetValue(ElementColorProperty); }
            set { SetValue(ElementColorProperty, value); }
        }

        public string ElementText
        {
            get { return (string)GetValue(ElementTextProperty); }
            set { SetValue(ElementTextProperty, value); }
        }

        public ColorElement()
        {
        }

        private static void OnElementColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (ColorElement)bindable;
            element.BackgroundColor = (Color)newValue;
        }

        private static void OnElementTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (ColorElement)bindable;
            element.Text = (string)newValue;
        }
    }

}
