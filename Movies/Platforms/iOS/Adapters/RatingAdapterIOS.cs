#if __IOS__
using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
using CoreGraphics;
using Movies.Controls;
using Microsoft.Maui.Controls;

namespace Movies.NativeViews
{
    public class StarCell : UICollectionViewCell
    {
        public UIImageView StarImage { get; set; }
        public static string CellId = "StarCell";

        [Export("initWithFrame:")]
        public StarCell(CGRect frame) : base(frame)
        {
            StarImage = new UIImageView(frame);
            ContentView.AddSubview(StarImage);
        }

        public void ChangeSize(nfloat size)
        {
            StarImage.Frame = new CGRect(0, 0, size, size);
        }
    }

    public class RatingAdapterIOS : UICollectionViewDataSource
    {
        public int TotalNumberOfStars { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }
        public Shape Shape { get; set; }

        public nfloat StarsSize { get; set; } = 40;

        private List<RatingElement> _stars;

        public RatingAdapterIOS(List<RatingElement> stars)
        {
            _stars = stars;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (StarCell)collectionView.DequeueReusableCell(StarCell.CellId, indexPath);
            cell.ChangeSize(StarsSize);

            SetupClickHandler(cell, indexPath.Row, collectionView);
            ConfigureStarShape(cell, indexPath.Row);
            ConfigureStarColor(cell, indexPath.Row);

            return cell;
        }

        private void SetupClickHandler(StarCell starCell, int position, UICollectionView collectionView)
        {
            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(() =>
            {
                Value = position + 1;
                collectionView.ReloadData();
            });

            starCell.AddGestureRecognizer(tapGesture);
        }

        private void ConfigureStarShape(StarCell starCell, int position)
        {
            UIImage image = GetImageForShapeAndPosition(Shape, position);
            starCell.StarImage.Image = image;
        }

        private UIImage GetImageForShapeAndPosition(Shape shape, int position)
        {
            bool isFilled = position < Value;
            UIImage image;

            switch (shape)
            {
                case Shape.Square:
                    image = isFilled ? UIImage.FromBundle("square_filled") : UIImage.FromBundle("square_unfilled");
                    break;
                case Shape.Circle:
                    image = isFilled ? UIImage.FromBundle("circle_filled") : UIImage.FromBundle("circle_unfilled");
                    break;
                case Shape.Star:
                    image = isFilled ? UIImage.FromBundle("star_filled") : UIImage.FromBundle("star_unfilled");
                    break;
                default:
                    image = null;
                    break;
            }

            return image;
        }

        private void ConfigureStarColor(StarCell starCell, int position)
        {
            if (position < Value)
            {
                UIColor uiColor = UIColor.Clear;

                //if (ColorUtil.TryGetColor(Color, out uiColor))
                //{
                //    starCell.StarImage.TintColor = uiColor;
                //}
            }
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return TotalNumberOfStars;
        }
    }
}
#endif
