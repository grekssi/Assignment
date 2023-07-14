using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using AndroidX.Core.Content;
using AndroidX.Core.Graphics.Drawable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.NativeViews
{
    public class NativeRatingView : Android.Views.View
    {
        private int _value;
        private Drawable _starEmpty;
        private Drawable _starFull;
        private Android.Graphics.Color _color;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        public Android.Graphics.Color Color
        {
            get => _color;
            set
            {
                _color = value;
            }
        }

        public void SetColor(Android.Graphics.Color color)
        {
            Color = color;

            var colorStateList = ColorStateList.ValueOf(color);

            DrawableCompat.SetTintList(_starEmpty, colorStateList);
            DrawableCompat.SetTintList(_starFull, colorStateList);

            Invalidate();
        }

        public void SetValue(int value)
        {
            Value = value;
            Invalidate();
        }

        public NativeRatingView(Context context) : base(context)
        {
            _starEmpty = ContextCompat.GetDrawable(context, Resource.Drawable.star_unfilled_vector);
            _starFull = ContextCompat.GetDrawable(context, Resource.Drawable.star_filled_vector);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int heightSize = MeasureSpec.GetSize(heightMeasureSpec);

            SetMeasuredDimension(widthMeasureSpec, heightSize);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            int starWidth = 150;
            int starHeight = 150;

            int totalStarsWidth = 5 * starWidth + 4 * 10; 

            int leftStart = (Width - totalStarsWidth) / 2;
            int topStart = (Height - starHeight) / 2;

            for (int i = 0; i < 5; i++)
            {
                Drawable star = i < _value ? _starFull : _starEmpty;

                int left = leftStart + i * (starWidth + 10);

                star.SetBounds(left, topStart, left + starWidth, topStart + starHeight);
                star.Draw(canvas);
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Up)
            {
                int starWidth = 150;
                int totalStarsWidth = 5 * starWidth + 4 * 10; 

                int leftStart = (Width - totalStarsWidth) / 2;

                int index = (int)((e.GetX() - leftStart) / (starWidth + 10));

                if (index >= 0 && index < 5)
                {
                    _value = index + 1;
                }

                Invalidate();
            }

            return true;
        }

    }
}
