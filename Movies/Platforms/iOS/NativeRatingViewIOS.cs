#if __IOS__
using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;
using Foundation;
using Microsoft.Maui.Controls;
using Movies.NativeViews;
using Movies.Controls;

namespace Movies.Platforms.iOS
{
    public class NativeRatingViewIOS : UIView
    {
        private int _totalNumberOfStars = 5;
        private RatingAdapterIOS ratingAdapter;
        private UICollectionView myCollectionView;

        public int TotalNumberOfStars
        {
            get => _totalNumberOfStars;
            set
            {
                _totalNumberOfStars = value;
                ratingAdapter.TotalNumberOfStars = value;
                myCollectionView.ReloadData();
            }
        }

        public void SetCurrentWidth(nfloat width)
        {
            if (ratingAdapter != null)
            {
                ratingAdapter.StarsSize = width;
                myCollectionView.ReloadData();
            }
        }

        public void SetShape(Shape shape, string color)
        {
            if (ratingAdapter != null)
            {
                ratingAdapter.Shape = shape;
                myCollectionView.ReloadData();
            }

            SetNeedsDisplay();
        }

        public void SetColor(string color)
        {
            if (ratingAdapter != null)
            {
                this.ratingAdapter.Color = color;
                myCollectionView.ReloadData();
            }

            SetNeedsDisplay();
        }

        public void SetTotalNumberOfStars(int number)
        {
            if (ratingAdapter != null)
            {
                this.ratingAdapter.TotalNumberOfStars = number;
                myCollectionView.ReloadData();
            }

            SetNeedsDisplay();
        }

        public void SetValue(int value)
        {
            if (ratingAdapter != null)
            {
                ratingAdapter.Value = value;
                myCollectionView.ReloadData();
            }

            SetNeedsDisplay();
        }

        public NativeRatingViewIOS(CGRect frame) : base(frame)
        {
            InitializeCollectionView();
            SetupRatingAdapter();
        }

        private void InitializeCollectionView()
        {
            var layout = new UICollectionViewFlowLayout
            {
                ScrollDirection = UICollectionViewScrollDirection.Horizontal,
                MinimumInteritemSpacing = 0,
                MinimumLineSpacing = 0
            };

            myCollectionView = new UICollectionView(Bounds, layout);
            myCollectionView.AllowsSelection = false;
            myCollectionView.AllowsMultipleSelection = false;

            AddSubview(myCollectionView);
        }

        private void SetupRatingAdapter()
        {
            List<RatingElement> stars = CreateStarsList(TotalNumberOfStars);
            ratingAdapter = new RatingAdapterIOS(stars);
            ratingAdapter.TotalNumberOfStars = TotalNumberOfStars;

            myCollectionView.RegisterClassForCell(typeof(StarCell), StarCell.CellId);
            myCollectionView.DataSource = ratingAdapter;
            myCollectionView.ReloadData();
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
