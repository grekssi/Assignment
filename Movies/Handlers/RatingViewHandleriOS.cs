#if IOS
using Microsoft.Maui.Handlers;
using Movies.Controls;
using Movies.Platforms.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Handlers
{
    public partial class RatingViewHandleriOS : ViewHandler<RatingView, NativeRatingViewiOS>
    {
        public static IPropertyMapper<RatingView, RatingViewHandleriOS> PropertyMapper = new PropertyMapper<RatingView, RatingViewHandleriOS>(ViewHandler.ViewMapper)
        {
            [nameof(RatingView.Value)] = MapValue,
            [nameof(RatingView.Color)] = MapColor,
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

        protected override NativeRatingViewiOS CreatePlatformView()
        {
            return new NativeRatingViewiOS(new CoreGraphics.CGRect(0, 0, 100, 100));
        }
    }
}
#endif