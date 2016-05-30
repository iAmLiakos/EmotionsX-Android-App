package md53aee0c79afc9eed958ce1407f52c6c40;


public class CameraFragment_ImageAvailableListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.media.ImageReader.OnImageAvailableListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onImageAvailable:(Landroid/media/ImageReader;)V:GetOnImageAvailable_Landroid_media_ImageReader_Handler:Android.Media.ImageReader/IOnImageAvailableListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("EmotionsX.Droid.CameraFragment+ImageAvailableListener, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraFragment_ImageAvailableListener.class, __md_methods);
	}


	public CameraFragment_ImageAvailableListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraFragment_ImageAvailableListener.class)
			mono.android.TypeManager.Activate ("EmotionsX.Droid.CameraFragment+ImageAvailableListener, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onImageAvailable (android.media.ImageReader p0)
	{
		n_onImageAvailable (p0);
	}

	private native void n_onImageAvailable (android.media.ImageReader p0);

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
