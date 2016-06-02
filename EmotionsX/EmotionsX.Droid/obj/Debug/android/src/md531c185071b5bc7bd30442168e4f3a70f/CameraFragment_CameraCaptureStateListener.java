package md531c185071b5bc7bd30442168e4f3a70f;


public class CameraFragment_CameraCaptureStateListener
	extends android.hardware.camera2.CameraCaptureSession.StateCallback
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onConfigureFailed:(Landroid/hardware/camera2/CameraCaptureSession;)V:GetOnConfigureFailed_Landroid_hardware_camera2_CameraCaptureSession_Handler\n" +
			"n_onConfigured:(Landroid/hardware/camera2/CameraCaptureSession;)V:GetOnConfigured_Landroid_hardware_camera2_CameraCaptureSession_Handler\n" +
			"";
		mono.android.Runtime.register ("EmotionsX.Droid.CameraFragment+CameraCaptureStateListener, EmotionsX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraFragment_CameraCaptureStateListener.class, __md_methods);
	}


	public CameraFragment_CameraCaptureStateListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraFragment_CameraCaptureStateListener.class)
			mono.android.TypeManager.Activate ("EmotionsX.Droid.CameraFragment+CameraCaptureStateListener, EmotionsX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onConfigureFailed (android.hardware.camera2.CameraCaptureSession p0)
	{
		n_onConfigureFailed (p0);
	}

	private native void n_onConfigureFailed (android.hardware.camera2.CameraCaptureSession p0);


	public void onConfigured (android.hardware.camera2.CameraCaptureSession p0)
	{
		n_onConfigured (p0);
	}

	private native void n_onConfigured (android.hardware.camera2.CameraCaptureSession p0);

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
