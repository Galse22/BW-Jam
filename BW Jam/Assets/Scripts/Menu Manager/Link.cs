using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Link : MonoBehaviour {

	public void OpenYT () {
#if !UNITY_EDITOR
		openWindow ("https://www.youtube.com/channel/UCBgA6tSAxLkdLJVAILqZLuQ");
#endif
	}

	public void OpenSoundcloud () {
#if !UNITY_EDITOR
		openWindow ("https://soundcloud.com/user-829631810");
#endif
	}

	[DllImport ("__Internal")]
	private static extern void openWindow (string url);

}