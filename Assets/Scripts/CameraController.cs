using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public CameraConfig Config;

	void Start ()
	{
		
	}

	Vector3 _prevMousePos;
	float _startTime;
	bool _update;

	void Update ()
	{
		if (Input.GetKey(KeyCode.Mouse0) && _update && (Time.time-_startTime ) >= Config.ReactTime)
		{
			var delta = _prevMousePos - Input.mousePosition;
			transform.Translate(delta * Config.Sensitivity);
			transform.LookAt(Vector3.zero);


			_prevMousePos = Input.mousePosition;
		}

		Config.Distance -= Input.mouseScrollDelta.y;
		Vector3 toCam = -transform.forward * Config.Distance;
		transform.position = toCam;
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			_prevMousePos = Input.mousePosition;
			_update = true;
			_startTime = Time.time;
		}

		if(Input.GetKeyUp(KeyCode.Mouse0))
		{
			_prevMousePos = Vector3.zero;
			_update = false;
		}

	}
}
