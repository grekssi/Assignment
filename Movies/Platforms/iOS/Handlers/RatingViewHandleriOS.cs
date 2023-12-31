﻿#if IOS
using CoreGraphics;
using Microsoft.Maui.Handlers;
using Movies.Controls;

namespace Movies.Platforms.iOS.Handlers
{
    public partial class RatingViewHandleriOS : ViewHandler<RatingView, NativeRatingViewIOS>
    {
        public static IPropertyMapper<RatingView, RatingViewHandleriOS> PropertyMapper = new PropertyMapper<RatingView, RatingViewHandleriOS>(ViewHandler.ViewMapper)
        {
            [nameof(RatingView.ElementWidth)] = MapWidth,
            [nameof(RatingView.Value)] = MapValue,
            [nameof(RatingView.Shape)] = MapShape,
            [nameof(RatingView.Color)] = MapColor,
            [nameof(RatingView.TotalStars)] = MapTotalNumberOfStars,
        };

        public static CommandMapper<RatingView, RatingViewHandleriOS> CommandMapper = new(ViewCommandMapper)
        {
        };

        public RatingViewHandleriOS() : base(PropertyMapper, CommandMapper)
        {
        }

        public static void MapValue(RatingViewHandleriOS handler, RatingView view)
        {
            handler.PlatformView?.SetValue(view.Value);
        }

        public static void MapColor(RatingViewHandleriOS handler, RatingView view)
        {
            handler.PlatformView?.SetColor(view.Color);
        }

        public static void MapTotalNumberOfStars(RatingViewHandleriOS handler, RatingView view)
        {
            handler.PlatformView?.SetTotalNumberOfStars(view.TotalStars);
        }

        public static void MapShape(RatingViewHandleriOS handler, RatingView view)
        {
            handler.PlatformView?.SetShape(view.Shape, view.Color);
        }

        public static void MapWidth(RatingViewHandleriOS handler, RatingView view)
        {
            handler.PlatformView?.SetCurrentWidth((nfloat)view.ElementWidth);
        }

        protected override NativeRatingViewIOS CreatePlatformView()
        {
            var frame = new CGRect(0, 0, 500, 50);
            return new NativeRatingViewIOS(frame);
        }
    }
}
#endif