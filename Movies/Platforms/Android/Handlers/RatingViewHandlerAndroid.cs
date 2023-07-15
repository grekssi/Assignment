#if ANDROID
using Android.Content;
using Microsoft.Maui;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Handlers;
using Movies.Controls;
using Movies.NativeViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.MediaStore;

namespace Movies.Platforms.Android.Handlers
{
    public partial class RatingViewHandlerAndroid : ViewHandler<RatingView, NativeRatingView>
    {
        public static IPropertyMapper<RatingView, RatingViewHandlerAndroid> PropertyMapper = new PropertyMapper<RatingView, RatingViewHandlerAndroid>(ViewHandler.ViewMapper)
        {
            [nameof(RatingView.ElementWidth)] = MapWidth,
            [nameof(RatingView.Value)] = MapValue,
            [nameof(RatingView.Shape)] = MapShape,
            [nameof(RatingView.Color)] = MapColor,
            [nameof(RatingView.TotalStars)] = MapTotalNumberOfStars,
        };

        public static CommandMapper<RatingView, RatingViewHandlerAndroid> CommandMapper = new(ViewCommandMapper)
        {
        };

        public RatingViewHandlerAndroid() : base(PropertyMapper, CommandMapper)
        {
        }

        public static void MapValue(RatingViewHandlerAndroid handler, RatingView view)
        {
            handler.PlatformView?.SetValue(view.Value);
        }

        public static void MapColor(RatingViewHandlerAndroid handler, RatingView view)
        {
            handler.PlatformView?.SetColor(view.Color);
        } 
        
        public static void MapTotalNumberOfStars(RatingViewHandlerAndroid handler, RatingView view)
        {
            handler.PlatformView?.SetTotalNumberOfStars(view.TotalStars);
        }

        public static void MapShape(RatingViewHandlerAndroid handler, RatingView view)
        {
            handler.PlatformView?.SetShape(view.Shape, view.Color);
        }

        public static void MapWidth(RatingViewHandlerAndroid handler, RatingView view)
        {
            handler.PlatformView?.SetCurrentWidth(view.ElementWidth);
        }

        protected override NativeRatingView CreatePlatformView()
        {
            return new NativeRatingView(Context);
        }
    }
}
#endif