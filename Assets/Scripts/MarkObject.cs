using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkObject : MonoBehaviour
{
	public Action OnClick;
	public HullBuilder Builder;

	void OnMouseDown()
	{
		Debug.Log("MouseDown");
		if (OnClick != null)
		{
			OnClick();
		}
	}

	public void Toggle()
	{
		var o = GetComponent<cakeslice.Outline>();
		if(o != null)
			o.enabled = !o.enabled;
	}

	void Update()
	{
		var o = GetComponent<cakeslice.Outline>();
		if (o != null && o.enabled && Input.GetKeyDown(KeyCode.Delete))
		{
			Builder.TryRemove(this.gameObject);
		}
	}
}
