using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;
using Movies.Controls;
//using Movies.Platforms.iOS.Adapters;

namespace Movies.NativeViews
{
    public class NativeRatingViewIOS : UIView
    {
        private int _value;
        private int _currentWidth;
        private int _totalNumberOfStars = 5;
        //private RatingAdapter starAdapter;
        private UICollectionView myCollectionView;

        public int TotalNumberOfStars
        {
            get => _totalNumberOfStars;
            set
            {
                _totalNumberOfStars = value;
            }
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        public int CurrentWidth
        {
            get => _currentWidth;
            set
            {
                _currentWidth = value;
            }
        }

        public void SetShape(Shape shape, string color)
        {
            //if (starAdapter != null)
            //{
            //    starAdapter.Shape = shape;
            //}
        }

        public void SetColor(string color)
        {
            //if (starAdapter != null)
            //{
            //    this.starAdapter.Color = color;
            //}
        }

        public void SetValue(int value)
        {
            Value = value;
            //if (starAdapter != null)
            //{
            //    starAdapter.Value = Value;
            //}
        }

        public NativeRatingViewIOS(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        public NativeRatingViewIOS(CGRect frame) : base(frame)
        {
            Initialize();
        }

        private void Initialize()
        {
            var layout = new UICollectionViewFlowLayout();
            layout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
            myCollectionView = new UICollectionView(Frame, layout);
            AddSubview(myCollectionView);
            myCollectionView.TranslatesAutoresizingMaskIntoConstraints = false;

            myCollectionView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
            myCollectionView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
            myCollectionView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            myCollectionView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;

            List<RatingElement> stars = new List<RatingElement>();
            for (int i = 0; i < TotalNumberOfStars; i++)
            {
                stars.Add(new RatingElement());
            }

            //starAdapter = new RatingAdapter(stars);
            //starAdapter.TotalNumberOfStars = TotalNumberOfStars;

            //myCollectionView.RegisterClassForCell(typeof(StarCell), StarCell.Key);
            //myCollectionView.DataSource = starAdapter;
            //myCollectionView.Delegate = new StarDelegate(starAdapter);
        }
    }
}