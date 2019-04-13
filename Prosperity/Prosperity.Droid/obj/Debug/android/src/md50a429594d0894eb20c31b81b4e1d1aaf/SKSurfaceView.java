package md50a429594d0894eb20c31b81b4e1d1aaf;


public class SKSurfaceView
	extends android.view.SurfaceView
	implements
		mono.android.IGCUserPeer,
		android.view.SurfaceHolder.Callback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_surfaceChanged:(Landroid/view/SurfaceHolder;III)V:GetSurfaceChanged_Landroid_view_SurfaceHolder_IIIHandler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_surfaceCreated:(Landroid/view/SurfaceHolder;)V:GetSurfaceCreated_Landroid_view_SurfaceHolder_Handler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_surfaceDestroyed:(Landroid/view/SurfaceHolder;)V:GetSurfaceDestroyed_Landroid_view_SurfaceHolder_Handler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Android.SKSurfaceView, SkiaSharp.Views.Android, Version=1.59.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756", SKSurfaceView.class, __md_methods);
	}


	public SKSurfaceView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SKSurfaceView.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKSurfaceView, SkiaSharp.Views.Android, Version=1.59.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public SKSurfaceView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SKSurfaceView.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKSurfaceView, SkiaSharp.Views.Android, Version=1.59.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public SKSurfaceView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SKSurfaceView.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKSurfaceView, SkiaSharp.Views.Android, Version=1.59.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SKSurfaceView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SKSurfaceView.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKSurfaceView, SkiaSharp.Views.Android, Version=1.59.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void surfaceChanged (android.view.SurfaceHolder p0, int p1, int p2, int p3)
	{
		n_surfaceChanged (p0, p1, p2, p3);
	}

	private native void n_surfaceChanged (android.view.SurfaceHolder p0, int p1, int p2, int p3);


	public void surfaceCreated (android.view.SurfaceHolder p0)
	{
		n_surfaceCreated (p0);
	}

	private native void n_surfaceCreated (android.view.SurfaceHolder p0);


	public void surfaceDestroyed (android.view.SurfaceHolder p0)
	{
		n_surfaceDestroyed (p0);
	}

	private native void n_surfaceDestroyed (android.view.SurfaceHolder p0);

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
