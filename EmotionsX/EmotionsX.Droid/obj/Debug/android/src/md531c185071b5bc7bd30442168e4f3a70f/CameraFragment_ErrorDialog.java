package md531c185071b5bc7bd30442168e4f3a70f;


public class CameraFragment_ErrorDialog
	extends android.app.DialogFragment
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateDialog:(Landroid/os/Bundle;)Landroid/app/Dialog;:GetOnCreateDialog_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("EmotionsX.Droid.CameraFragment+ErrorDialog, EmotionsX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraFragment_ErrorDialog.class, __md_methods);
	}


	public CameraFragment_ErrorDialog () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraFragment_ErrorDialog.class)
			mono.android.TypeManager.Activate ("EmotionsX.Droid.CameraFragment+ErrorDialog, EmotionsX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public android.app.Dialog onCreateDialog (android.os.Bundle p0)
	{
		return n_onCreateDialog (p0);
	}

	private native android.app.Dialog n_onCreateDialog (android.os.Bundle p0);

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
