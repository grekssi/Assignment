#if ANDROID
using Android.Content;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Graphics.Drawable;
using AndroidX.RecyclerView.Widget;
using Movies.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.NativeViews
{
    public class StarViewHolder : RecyclerView.ViewHolder
    {
        public ImageView StarImage { get; set; }

        public StarViewHolder(Android.Views.View itemView) : base(itemView)
        {
            StarImage = itemView.FindViewById<ImageView>(Resource.Id.star_image);
        }

        public void ChangeSize(double size)
        {
            float scale = this.ItemView.Context.Resources.DisplayMetrics.Density;
            int newWidthPx = (int)(size * scale + 0.5f);
            int newHeightPx = (int)(size * scale + 0.5f);

            ViewGroup.LayoutParams layoutParams = StarImage.LayoutParameters;
            layoutParams.Width = newWidthPx;
            layoutParams.Height = newHeightPx;
            StarImage.LayoutParameters = layoutParams;

        }
    }

    public class StarAdapter : RecyclerView.Adapter
    {
        public int TotalNumberOfStars { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }
        public Shape Shape { get; set; }

        public double StarsSize { get; set; } = 40;

        private List<RatingElement> _stars;

        public StarAdapter(List<RatingElement> stars)
        {
            _stars = stars;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Android.Views.View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Drawable.rating_item, parent, false);
            return new StarViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            StarViewHolder starViewHolder = holder as StarViewHolder;
            starViewHolder.ChangeSize(StarsSize);

            starViewHolder.StarImage.Click += (sender, e) =>
            {
                Value = position + 1;
                NotifyDataSetChanged();
            };

            if (position < Value)
            {
                switch (Shape)
                {
                    case Shape.Square:
                        starViewHolder.StarImage.SetImageResource(Resource.Drawable.square_filled_vector);
                        break;
                    case Shape.Circle:
                        starViewHolder.StarImage.SetImageResource(Resource.Drawable.circle_filled_vector);
                        break;
                    case Shape.Star:
                        starViewHolder.StarImage.SetImageResource(Resource.Drawable.star_filled_vector);
                        break;
                    default:
                        break;
                }

                var androidColor = Android.Graphics.Color.ParseColor(Color);
                var colorStateList = ColorStateList.ValueOf(androidColor);
                DrawableCompat.SetTintList(starViewHolder.StarImage.Drawable, colorStateList);
            }
            else
            {
                switch (Shape)
                {
                    case Shape.Square:
                        starViewHolder.StarImage.SetImageResource(Resource.Drawable.square_unfilled_vector);
                        break;
                    case Shape.Circle:
                        starViewHolder.StarImage.SetImageResource(Resource.Drawable.circle_unfilled_vector);
                        break;
                    case Shape.Star:
                        starViewHolder.StarImage.SetImageResource(Resource.Drawable.star_unfilled_vector);
                        break;
                    default:
                        break;
                }
            }
        }

        public override int ItemCount => TotalNumberOfStars;
    }

}
#endif