using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;
using UnityEditor;


public class HullBuilder : MonoBehaviour
{
	public HullPieces HullPieces;
	private List<GameObject> _pieces = new List<GameObject>();

	void Start ()
	{
		CreateBase(HullPieces);
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			AddCenterPiece(HullPieces.Centers[0]);
		}
		else if(Input.GetKeyDown(KeyCode.KeypadMinus) && _pieces.Count >= 3)
		{
			RemoveCenterPiece();
		}
	}

	public void CreateBase(HullPieces pieces)
	{
		Assert.AreNotEqual(0, pieces.Bows.Count, "No bows!");
		Assert.AreNotEqual(0, pieces.Centers.Count, "No centers!");
		Assert.AreNotEqual(0, pieces.Sterns.Count, "No sterns!");

		var bow = Instantiate(pieces.Bows[0]);
		var center = Instantiate(pieces.Centers[0]);
		var stern = Instantiate(pieces.Sterns[0]);

		_pieces.Add(bow);
		_pieces.Add(center);
		_pieces.Add(stern);

		Connect(bow, center);
		Connect(center, stern);
	}

	public void AddCenterPiece(GameObject centerPiece)
	{
		Assert.IsTrue(_pieces.Count >= 2, "Too few hull pieces");

		int c = _pieces.Count;

		var prevLastCenter = _pieces[c - 2];
		var stern =  _pieces[c - 1];
		var newLastCenter = Instantiate(centerPiece);

		Connect(prevLastCenter, newLastCenter);
		Connect(newLastCenter, stern);

		_pieces.Insert(c-1, newLastCenter);
	}

	public void RemoveCenterPiece()
	{
		Assert.IsTrue(_pieces.Count >= 3, "Can't remove bow or stern");

		int c = _pieces.Count;

		var toRemove = _pieces[c - 2];
		_pieces.RemoveAt(c - 2);
		Destroy(toRemove);

		c = _pieces.Count;
		var stern = _pieces[c - 1];
		var preStern = _pieces[c - 2];

		Connect(preStern, stern);
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
