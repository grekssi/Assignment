#if ANDROID
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using AndroidX.ConstraintLayout.Widget;
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
    public class NativeRatingView : ConstraintLayout
    {
        private int _totalNumberOfStars = 5;
        private RatingAdapter ratingAdapter;
        private RecyclerView myRecyclerView;

        public int TotalNumberOfStars
        {
            get => _totalNumberOfStars;
            set
            {
                _totalNumberOfStars = value;
            }
        }

        public void SetTotalNumberOfStars(int stars)
        {
            if (ratingAdapter != null)
            {
                ratingAdapter.TotalNumberOfStars = stars;
                ratingAdapter.NotifyDataSetChanged();
            }
        }

        public void SetCurrentWidth(double width)
        {
            if (ratingAdapter != null)
            {
                ratingAdapter.StarsSize = width;
                ratingAdapter.NotifyDataSetChanged();
            }
        }

        public void SetShape(Shape shape, string color)
        {
            if (ratingAdapter != null)
            {
                ratingAdapter.Shape = shape;
                ratingAdapter.NotifyDataSetChanged();
            }

            Invalidate();
        }

        public void SetColor(string color)
        {
            if (ratingAdapter != null)
            {
                this.ratingAdapter.Color = color;
                ratingAdapter.NotifyDataSetChanged();
            }

            Invalidate();
        }

        public void SetValue(int value)
        {
            if (ratingAdapter != null)
            {
                ratingAdapter.Value = value;
                ratingAdapter.NotifyDataSetChanged();
            }

            Invalidate();
        }

        public NativeRatingView(Context context) : base(context)
        {
            InflateView(context);
            ConfigureLayoutParameters();
            InitializeRecyclerView(context);
            SetupRatingAdapter();
        }

        private void InflateView(Context context)
        {
            Inflate(context, Resource.Drawable.rating_layout, this);
        }

        private void ConfigureLayoutParameters()
        {
            LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
        }

        private void InitializeRecyclerView(Context context)
        {
            myRecyclerView = FindViewById<RecyclerView>(Resource.Id.my_recycler_view);
            myRecyclerView.SetLayoutManager(new UnscrollableLinearLayoutManager(context, LinearLayoutManager.Horizontal, false));
        }

        private void SetupRatingAdapter()
        {
            List<RatingElement> stars = CreateStarsList(TotalNumberOfStars);
            ratingAdapter = new RatingAdapter(stars);
            ratingAdapter.TotalNumberOfStars = TotalNumberOfStars;

            myRecyclerView.SetAdapter(ratingAdapter);
        }

        private List<RatingElement> CreateStarsList(int numberOfStars)
        {
            List<RatingElement> stars = new List<RatingElement>();
            for (int i = 0; i < numberOfStars; i++)
            {
                stars.Add(new RatingElement());
            }

            return stars;
        }
    }
}
#endif