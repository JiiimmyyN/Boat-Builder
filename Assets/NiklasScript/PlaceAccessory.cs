using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAccessory : PlaceObject
{
	public static bool Holding;
	public PlaceState CurrentState;
	public enum PlaceState
	{
		Placing,
		Rotating,
		Placed
	}
	Vector3 _mousePos;
	public override void Place(Vector3 mousePos)
	{
		throw new NotImplementedException();
	}
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	private bool hitChilds(Transform[] trans, Transform hit)
	{
		for (int i = 0; i < trans.Length; i++)
		{
			if (trans[i] == hit)
				return true;
        }
		return false;
	}
	void Update()
	{
		if (CurrentState == PlaceState.Placed)
		{
			if (Input.GetKeyDown(KeyCode.Mouse1) && !Holding)
			{
				RaycastHit hit2;
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				var transforms = GetComponentsInChildren<Transform>();
				if (Physics.Raycast(ray2, out hit2))
				{
					if (hit2.transform == transform || hitChilds(transforms, hit2.transform))
					{

						CurrentState = PlaceState.Placing;
						DeActivateMeshCollider();
                    }
				}
			}
			return;
		}
		
		if (CurrentState == PlaceState.Placing)
		{
			Holding = true;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			var transforms = GetComponentsInChildren<Transform>();
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform != transform || hitChilds(transforms, hit.transform))
				{
					transform.position = hit.point;
					var proj = transform.forward - (Vector3.Dot(transform.forward, hit.normal)) * hit.normal;
					transform.rotation = Quaternion.LookRotation(proj, hit.normal);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			_mousePos = Input.mousePosition;
            CurrentState = PlaceState.Rotating;
		}
		if (CurrentState == PlaceState.Rotating)
		{
			float diff = _mousePos.x - Input.mousePosition.x;
			_mousePos = Input.mousePosition;
			transform.RotateAroundLocal(transform.up, diff * 0.01f);

			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				ActivateMeshCollider();
				Holding = false;
				CurrentState = PlaceState.Placed;
			}
		}
	}
	public void ActivateMeshCollider()
	{
		var children = GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter mf in children)
		{
			if (mf.gameObject.GetComponent<MeshCollider>() == null)
				mf.gameObject.AddComponent<MeshCollider>();
			else
				mf.gameObject.GetComponent<MeshCollider>().enabled = true;
		}

	}
	public void DeActivateMeshCollider()
	{
		var children = GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter mf in children)
		{
			if (mf.gameObject.GetComponent<MeshCollider>() != null)
				mf.gameObject.GetComponent<MeshCollider>().enabled = false;
		}
	}
}
