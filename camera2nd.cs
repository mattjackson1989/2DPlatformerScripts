using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

	
	
	public class camera2nd : MonoBehaviour {
	public Vector3 maxCameraPos;
	public Vector3 minCameraPos;
	public void SetMinCamPosition(){
		minCameraPos = gameObject.transform.position;
	}

	public void SetMaxCamPosition(){
		maxCameraPos = gameObject.transform.position;
	}
}
