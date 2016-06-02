package md531c185071b5bc7bd30442168e4f3a70f;


public class CameraFragment_CameraCaptureListener
	extends android.hardware.camera2.CameraCaptureSession.CaptureCallback
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCaptureCompleted:(Landroid/hardware/camera2/CameraCaptureSession;Landroid/hardware/camera2/CaptureRequest;Landroid/hardware/camera2/TotalCaptureResult;)V:GetOnCaptureCompleted_Landroid_hardware_camera2_CameraCaptureSession_Landroid_hardware_camera2_CaptureRequest_Landroid_hardware_camera2_TotalCaptureResult_Handler\n" +
			"";
		mono.android.Runtime.register ("EmotionsX.Droid.CameraFragment+CameraCaptureListener, EmotionsX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraFragment_CameraCaptureListener.class, __md_methods);
	}


	public CameraFragment_CameraCaptureListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraFragment_CameraCaptureListener.class)
			mono.android.TypeManager.Activate ("EmotionsX.Droid.CameraFragment+CameraCaptureListener, EmotionsX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCaptureCompleted (android.hardware.camera2.CameraCaptureSession p0, android.hardware.camera2.CaptureRequest p1, android.hardware.camera2.TotalCaptureResult p2)
	{
		n_onCaptureCompleted (p0, p1, p2);
	}

	private native void n_onCaptureCompleted (android.hardware.camera2.CameraCaptureSession p0, android.hardware.camera2.CaptureRequest p1, android.hardware.camera2.TotalCaptureResult p2);

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
