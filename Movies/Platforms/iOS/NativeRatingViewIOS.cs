using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Movies.Platforms.iOS
{
    public class NativeRatingViewiOS : UIView
    {
        private int _value;
        private UIImage _starEmpty;
        private UIImage _starFull;
        private UIColor _color;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                SetNeedsDisplay();
            }
        }

        public UIColor Color
        {
            get => _color;
            set
            {
                _color = value;
                _starEmpty = _starEmpty.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                _starFull = _starFull.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                SetNeedsDisplay();
            }
        }
        public void SetColor(UIColor color)
        {
            Color = color;
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public NativeRatingViewiOS(CGRect frame) : base(frame)
        {
            _starEmpty = UIImage.FromBundle("star_unfilled_vector");
            _starFull = UIImage.FromBundle("star_filled_vector");
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            int starWidth = 150;
            int starHeight = 150;

            int totalStarsWidth = 5 * starWidth + 4 * 10;

            int leftStart = (int)((Bounds.Width - totalStarsWidth) / 2);
            int topStart = (int)((Bounds.Height - starHeight) / 2);

            for (int i = 0; i < 5; i++)
            {
                UIImage star = i < _value ? _starFull : _starEmpty;
                UIColor color = i < _value ? _color : UIColor.LightGray;

                var frame = new CGRect(leftStart + i * (starWidth + 10), topStart, starWidth, starHeight);

                color.SetFill();
                star.Draw(frame);
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            var touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                int starWidth = 150;
                int totalStarsWidth = 5 * starWidth + 4 * 10;

                int leftStart = (int)((Bounds.Width - totalStarsWidth) / 2);

                int index = (int)((touch.LocationInView(this).X - leftStart) / (starWidth + 10));

                if (index >= 0 && index < 5)
                {
                    _value = index + 1;
                    SetNeedsDisplay();
                }
            }
        }
    }

}
