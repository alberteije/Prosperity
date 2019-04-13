package md55430eeafbf000a5ac5c6dc7e4c10488b;


public class SKGLViewRenderer
	extends md55430eeafbf000a5ac5c6dc7e4c10488b.SKGLViewRendererBase_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Forms.SKGLViewRenderer, SkiaSharp.Views.Forms, Version=1.59.0.0, Culture=neutral, PublicKeyToken=null", SKGLViewRenderer.class, __md_methods);
	}


	public SKGLViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SKGLViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKGLViewRenderer, SkiaSharp.Views.Forms, Version=1.59.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SKGLViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SKGLViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKGLViewRenderer, SkiaSharp.Views.Forms, Version=1.59.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public SKGLViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SKGLViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKGLViewRenderer, SkiaSharp.Views.Forms, Version=1.59.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
