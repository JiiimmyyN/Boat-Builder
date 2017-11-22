using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAccessory : PlaceObject
{

	public override void Place(Vector3 mousePos)
	{
		throw new NotImplementedException();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			transform.position = hit.point;
			//Transform objectHit = hit.transform;

			// Do something with the object that was hit by the raycast.
		}
	}
}
