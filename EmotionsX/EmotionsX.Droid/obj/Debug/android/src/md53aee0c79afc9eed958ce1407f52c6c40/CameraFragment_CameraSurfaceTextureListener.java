package md53aee0c79afc9eed958ce1407f52c6c40;


public class CameraFragment_CameraSurfaceTextureListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.TextureView.SurfaceTextureListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onSurfaceTextureAvailable:(Landroid/graphics/SurfaceTexture;II)V:GetOnSurfaceTextureAvailable_Landroid_graphics_SurfaceTexture_IIHandler:Android.Views.TextureView/ISurfaceTextureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onSurfaceTextureDestroyed:(Landroid/graphics/SurfaceTexture;)Z:GetOnSurfaceTextureDestroyed_Landroid_graphics_SurfaceTexture_Handler:Android.Views.TextureView/ISurfaceTextureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onSurfaceTextureSizeChanged:(Landroid/graphics/SurfaceTexture;II)V:GetOnSurfaceTextureSizeChanged_Landroid_graphics_SurfaceTexture_IIHandler:Android.Views.TextureView/ISurfaceTextureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onSurfaceTextureUpdated:(Landroid/graphics/SurfaceTexture;)V:GetOnSurfaceTextureUpdated_Landroid_graphics_SurfaceTexture_Handler:Android.Views.TextureView/ISurfaceTextureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("EmotionsX.Droid.CameraFragment+CameraSurfaceTextureListener, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraFragment_CameraSurfaceTextureListener.class, __md_methods);
	}


	public CameraFragment_CameraSurfaceTextureListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraFragment_CameraSurfaceTextureListener.class)
			mono.android.TypeManager.Activate ("EmotionsX.Droid.CameraFragment+CameraSurfaceTextureListener, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public CameraFragment_CameraSurfaceTextureListener (md53aee0c79afc9eed958ce1407f52c6c40.CameraFragment p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraFragment_CameraSurfaceTextureListener.class)
			mono.android.TypeManager.Activate ("EmotionsX.Droid.CameraFragment+CameraSurfaceTextureListener, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "EmotionsX.Droid.CameraFragment, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onSurfaceTextureAvailable (android.graphics.SurfaceTexture p0, int p1, int p2)
	{
		n_onSurfaceTextureAvailable (p0, p1, p2);
	}

	private native void n_onSurfaceTextureAvailable (android.graphics.SurfaceTexture p0, int p1, int p2);


	public boolean onSurfaceTextureDestroyed (android.graphics.SurfaceTexture p0)
	{
		return n_onSurfaceTextureDestroyed (p0);
	}

	private native boolean n_onSurfaceTextureDestroyed (android.graphics.SurfaceTexture p0);


	public void onSurfaceTextureSizeChanged (android.graphics.SurfaceTexture p0, int p1, int p2)
	{
		n_onSurfaceTextureSizeChanged (p0, p1, p2);
	}

	private native void n_onSurfaceTextureSizeChanged (android.graphics.SurfaceTexture p0, int p1, int p2);


	public void onSurfaceTextureUpdated (android.graphics.SurfaceTexture p0)
	{
		n_onSurfaceTextureUpdated (p0);
	}

	private native void n_onSurfaceTextureUpdated (android.graphics.SurfaceTexture p0);

	java.util.ArrayList refList;
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
