package md50a429594d0894eb20c31b81b4e1d1aaf;


public class SKGLSurfaceView_InternalRenderer
	extends md50a429594d0894eb20c31b81b4e1d1aaf.SKGLSurfaceViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Android.SKGLSurfaceView+InternalRenderer, SkiaSharp.Views.Android, Version=1.59.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756", SKGLSurfaceView_InternalRenderer.class, __md_methods);
	}


	public SKGLSurfaceView_InternalRenderer ()
	{
		super ();
		if (getClass () == SKGLSurfaceView_InternalRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKGLSurfaceView+InternalRenderer, SkiaSharp.Views.Android, Version=1.59.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756", "", this, new java.lang.Object[] {  });
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
