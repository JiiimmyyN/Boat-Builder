using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;
using UnityEditor;


public class HullBuilder 
{
	private List<GameObject> _pieces = new List<GameObject>();

	public void Reset()
	{
		foreach(var piece in _pieces)
		{
			GameObject.Destroy(piece);
		}
		_pieces.Clear();
	}

	public void CreateBase(HullPieces pieces)
	{
		Assert.AreNotEqual(0, pieces.Bows.Count, "No bows!");
		Assert.AreNotEqual(0, pieces.Centers.Count, "No centers!");
		Assert.AreNotEqual(0, pieces.Sterns.Count, "No sterns!");

		var bow = GameObject.Instantiate(pieces.Bows[0]);
		var center = GameObject.Instantiate(pieces.Centers[0]);
		var stern = GameObject.Instantiate(pieces.Sterns[0]);

		_pieces.Add(bow);
		_pieces.Add(center);
		_pieces.Add(stern);

		Connect(bow, center);
		Connect(center, stern);
		
		AddClickControlls(center);
	}

	public void AddCenterPiece(GameObject centerPiece)
	{
		Assert.IsTrue(_pieces.Count >= 2, "Too few hull pieces");

		int c = _pieces.Count;

		var prevLastCenter = _pieces[c - 2];
		var stern =  _pieces[c - 1];
		var newLastCenter = GameObject.Instantiate(centerPiece);

		Connect(prevLastCenter, newLastCenter);
		Connect(newLastCenter, stern);

		_pieces.Insert(c-1, newLastCenter);

		AddClickControlls(newLastCenter);
	}

	private void AddClickControlls(GameObject go)
	{
		var rb = go.AddComponent<Rigidbody>();
		rb.freezeRotation = true;
		rb.isKinematic = true;
		var mark = go.AddComponent<MarkObject>();
		mark.Builder = this;
		mark.OnClick = () =>
		{
			Debug.Log("OnClick");
			if(_currentlyMarked != null)
			{
				_currentlyMarked.Toggle();
			}

			_currentlyMarked = mark;
			var o = mark.GetComponent<cakeslice.Outline>();
			if(o != null)
			{
				if(o.enabled)
				{
					o.enabled = false;
					_currentlyMarked = null;
				}
				else
				{
					o.enabled = true;
				}
			}
			else
			{
				_currentlyMarked.gameObject.AddComponent<cakeslice.Outline>();
			}
		};
		go.AddComponent<MeshCollider>().sharedMesh = go.GetComponent<MeshFilter>().mesh;
	}


	private MarkObject _currentlyMarked;

	public void RemoveCenterPiece()
	{
		Assert.IsTrue(_pieces.Count >= 3, "Can't remove bow or stern");

		int c = _pieces.Count;

		var toRemove = _pieces[c - 2];
		_pieces.RemoveAt(c - 2);
		GameObject.Destroy(toRemove);

		c = _pieces.Count;
		var stern = _pieces[c - 1];
		var preStern = _pieces[c - 2];

		Connect(preStern, stern);
	}

	public void TryRemove(GameObject p)
	{
		int i = _pieces.IndexOf(p);
		_pieces.RemoveAt(i);
		GameObject.Destroy(p);

		for(int j = i-1; j < _pieces.Count; j++)
		{
			if(!(j >= _pieces.Count-1))
			{
				var forward = _pieces[j];
				var backward = _pieces[j + 1];
				Connect(forward, backward);
			}
		}
	}

	/// <summary>
	/// Connect p1.Back with p2.Front
	/// Only moves the p2 object while p1 stays stationary
	/// </summary>
	/// <param name="p1">GameObject with child object with atleast one Connector set as Back</param>
	/// <param name="p2">GameObject with child object with atleast one Connector set as Front</param>
	public void Connect(GameObject p1, GameObject p2)
	{
		var p1Back = p1.GetComponentsInChildren<Connector>().First(con => con.Pos == Connector.Position.Back);
		var p2Front = p2.GetComponentsInChildren<Connector>().First(con => con.Pos == Connector.Position.Front);

		p2.transform.Translate(p1Back.transform.position - p2Front.transform.position);
	}

}

