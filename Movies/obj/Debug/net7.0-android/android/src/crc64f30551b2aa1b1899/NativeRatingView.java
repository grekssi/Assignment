package crc64f30551b2aa1b1899;


public class NativeRatingView
	extends androidx.constraintlayout.widget.ConstraintLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Movies.NativeViews.NativeRatingView, Movies", NativeRatingView.class, __md_methods);
	}


	public NativeRatingView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == NativeRatingView.class) {
			mono.android.TypeManager.Activate ("Movies.NativeViews.NativeRatingView, Movies", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public NativeRatingView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == NativeRatingView.class) {
			mono.android.TypeManager.Activate ("Movies.NativeViews.NativeRatingView, Movies", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public NativeRatingView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == NativeRatingView.class) {
			mono.android.TypeManager.Activate ("Movies.NativeViews.NativeRatingView, Movies", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public NativeRatingView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == NativeRatingView.class) {
			mono.android.TypeManager.Activate ("Movies.NativeViews.NativeRatingView, Movies", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
