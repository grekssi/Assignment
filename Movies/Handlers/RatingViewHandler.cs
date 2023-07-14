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

namespace Movies.Handlers
{
    public partial class RatingViewHandler : ViewHandler<RatingView, NativeRatingView>
    {
        public static IPropertyMapper<RatingView, RatingViewHandler> PropertyMapper = new PropertyMapper<RatingView, RatingViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(RatingView.Value)] = MapValue,
            [nameof(RatingView.Color)] = MapColor,
        };

        public static CommandMapper<RatingView, RatingViewHandler> CommandMapper = new(ViewCommandMapper)
        {
        };

        public RatingViewHandler() : base(PropertyMapper, CommandMapper)
        {
        }

        public static void MapValue(RatingViewHandler handler, RatingView view)
        {
            handler.PlatformView?.SetValue(view.Value);
        }

        public static void MapColor(RatingViewHandler handler, RatingView view)
        {
            handler.PlatformView?.SetColor(view.Color);
        }

        protected override NativeRatingView CreatePlatformView()
        {
            return new NativeRatingView(Context);
        }
    }
}
