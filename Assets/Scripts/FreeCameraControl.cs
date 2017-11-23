using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraControl : MonoBehaviour {

	public float MoveSpeed = 5;
	public float LookSpeed = 5;
	Vector3 mousePos;
	void Start()
	{
		// owt?
	}
	void Update()
	{
		if (Input.GetMouseButton(1))
		{
			float diffy = mousePos.y - Input.mousePosition.y;
			float diffx = mousePos.x - Input.mousePosition.x;

			var xAxis = Input.GetAxis("Horizontal");
			var yAxis = Input.GetAxis("Vertical");

			transform.position += transform.forward * yAxis * Time.deltaTime * MoveSpeed;
			transform.position += transform.right * xAxis * Time.deltaTime * MoveSpeed;
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//var lookatPos = transform.position + (ray.direction * 100);
			//transform.LookAt(lookatPos);
			float speed = LookSpeed / 1000;
            transform.RotateAroundLocal(transform.right, diffy * speed);
			transform.RotateAroundLocal(transform.up, diffx * -speed);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

		}
		mousePos = Input.mousePosition;
    }

}
