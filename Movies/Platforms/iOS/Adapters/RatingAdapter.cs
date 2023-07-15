//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using Foundation;
//using UIKit;
//using Movies.Controls;

//namespace Movies.Platforms.iOS.Adapters
//{
//    public class RatingAdapter : UICollectionViewDataSource
//    {
//        public int TotalNumberOfStars { get; set; }
//        public int Value { get; set; }
//        public string Color { get; set; }
//        public Shape Shape { get; set; }

//        private List<RatingElement> _stars;

//        public RatingAdapter(List<RatingElement> stars)
//        {
//            _stars = stars;
//        }

//        public override nint GetItemsCount(UICollectionView collectionView, nint section)
//        {
//            return _stars.Count;
//        }

//        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
//        {
//            var cell = (StarCell)collectionView.DequeueReusableCell(StarCell.Key, indexPath);

//            if (indexPath.Row < Value)
//            {
//                // Add logic to update the cell for filled star.
//                // For example, you can change the image of UIImageView based on Shape
//            }
//            else
//            {
//                // Add logic to update the cell for unfilled star.
//                // For example, you can change the image of UIImageView based on Shape
//            }

//            return cell;
//        }
//    }
//}
