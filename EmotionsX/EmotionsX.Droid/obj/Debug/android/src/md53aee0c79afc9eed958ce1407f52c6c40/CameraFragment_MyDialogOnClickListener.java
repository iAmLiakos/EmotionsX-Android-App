package md53aee0c79afc9eed958ce1407f52c6c40;


public class CameraFragment_MyDialogOnClickListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.content.DialogInterface.OnClickListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/content/DialogInterface;I)V:GetOnClick_Landroid_content_DialogInterface_IHandler:Android.Content.IDialogInterfaceOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("EmotionsX.Droid.CameraFragment+MyDialogOnClickListener, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraFragment_MyDialogOnClickListener.class, __md_methods);
	}


	public CameraFragment_MyDialogOnClickListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraFragment_MyDialogOnClickListener.class)
			mono.android.TypeManager.Activate ("EmotionsX.Droid.CameraFragment+MyDialogOnClickListener, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public CameraFragment_MyDialogOnClickListener (md53aee0c79afc9eed958ce1407f52c6c40.CameraFragment_ErrorDialog p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraFragment_MyDialogOnClickListener.class)
			mono.android.TypeManager.Activate ("EmotionsX.Droid.CameraFragment+MyDialogOnClickListener, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "EmotionsX.Droid.CameraFragment+ErrorDialog, EmotionsX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onClick (android.content.DialogInterface p0, int p1)
	{
		n_onClick (p0, p1);
	}

	private native void n_onClick (android.content.DialogInterface p0, int p1);

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
