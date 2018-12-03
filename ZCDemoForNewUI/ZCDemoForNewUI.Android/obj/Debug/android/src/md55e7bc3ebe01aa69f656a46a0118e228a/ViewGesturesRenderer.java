package md55e7bc3ebe01aa69f656a46a0118e228a;


public class ViewGesturesRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.ViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ScnViewGestures.Plugin.Forms.Droid.Renderers.ViewGesturesRenderer, ScnViewGestures.Droid", ViewGesturesRenderer.class, __md_methods);
	}


	public ViewGesturesRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ViewGesturesRenderer.class)
			mono.android.TypeManager.Activate ("ScnViewGestures.Plugin.Forms.Droid.Renderers.ViewGesturesRenderer, ScnViewGestures.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ViewGesturesRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ViewGesturesRenderer.class)
			mono.android.TypeManager.Activate ("ScnViewGestures.Plugin.Forms.Droid.Renderers.ViewGesturesRenderer, ScnViewGestures.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ViewGesturesRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ViewGesturesRenderer.class)
			mono.android.TypeManager.Activate ("ScnViewGestures.Plugin.Forms.Droid.Renderers.ViewGesturesRenderer, ScnViewGestures.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
