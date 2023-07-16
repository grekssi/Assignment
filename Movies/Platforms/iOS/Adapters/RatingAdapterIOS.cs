#if __IOS__
using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
using CoreGraphics;
using Movies.Controls;
using Microsoft.Maui.Controls;
using SkiaSharp;
using SkiaSharp.Extended.Svg;
using Movies.NativeViews;
using System.Reflection;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using System.Text;
using System.Xml;

namespace Movies.Platforms.iOS.Adapters
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
                    image = isFilled ? LoadSvg("Movies.Platforms.iOS.Resources.square_filled_vector.xml", isFilled) : LoadSvg("Movies.Platforms.iOS.Resources.square_unfilled_vector.xml", isFilled);
                    break;
                case Shape.Circle:
                    image = isFilled ? LoadSvg("Movies.Platforms.iOS.Resources.circle_filled_vector.xml", isFilled) : LoadSvg("Movies.Platforms.iOS.Resources.circle_unfilled_vector.xml", isFilled);
                    break;
                case Shape.Star:
                    image = isFilled ? LoadSvg("Movies.Platforms.iOS.Resources.star_filled_vector.xml", isFilled) : LoadSvg("Movies.Platforms.iOS.Resources.star_unfilled_vector.xml", isFilled);
                    break;
                default:
                    image = null;
                    break;
            }

            return image;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return TotalNumberOfStars;
        }

        public UIImage LoadSvg(string resourceName, bool isFilled)
        {
            var svg = new SkiaSharp.Extended.Svg.SKSvg();

            using (var stream = GetType().Assembly.GetManifestResourceStream(resourceName))
            {
                svg.Load(stream);
            }

            var bitmap = new SKBitmap((int)svg.CanvasSize.Width, (int)svg.CanvasSize.Height);

            using (var canvas = new SKCanvas(bitmap))
            {
                var paint = new SKPaint
                {
                    FilterQuality = SKFilterQuality.High,
                    ColorFilter = SKColorFilter.CreateBlendMode(SKColor.Parse(this.Color), SKBlendMode.SrcIn)
                };

                canvas.Clear(SKColors.Transparent);
                canvas.DrawPicture(svg.Picture, isFilled ? paint : null);
            }

            var image = SKImage.FromBitmap(bitmap);

            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            {
                return UIImage.LoadFromData(NSData.FromArray(data.ToArray()));
            }
        }


    }
}
#endif
