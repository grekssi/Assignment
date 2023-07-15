#if ANDROID
using Android.Content;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.NativeViews
{
    public class UnscrollableLinearLayoutManager : LinearLayoutManager
    {
        public UnscrollableLinearLayoutManager(Context context, int orientation, bool reverseLayout)
            : base(context, orientation, reverseLayout)
        {
        }

        public override bool CanScrollHorizontally() => false;

        public override bool CanScrollVertically() => false;
    }

}
#endif