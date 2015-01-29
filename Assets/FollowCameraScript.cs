using UnityEngine;
using System.Collections;

public class FollowCameraScript : MonoBehaviour {

	public Transform Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Target != null) 
		{
			Vector3 _targetPos = Target.position;
			_targetPos.z = transform.position.z;
			transform.position = _targetPos;
		}
	}
}
