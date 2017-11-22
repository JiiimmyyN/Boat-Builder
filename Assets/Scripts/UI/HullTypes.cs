using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class HullTypes : MonoBehaviour
{
	public Button HullTypePrototypeBtn;

	public List<HullPieces> Hulls;
	private HullBuilder _hb;

	void Start ()
	{
		Assert.IsFalse(Hulls == null, "No hulls!");

		_hb = new HullBuilder();

		foreach(var hullpieces in Hulls)
		{
			var typeBtn = Instantiate(HullTypePrototypeBtn, HullTypePrototypeBtn.transform.parent);
			typeBtn.gameObject.SetActive(true);
			typeBtn.gameObject.AddComponent<HullTypeButton>();
			typeBtn.GetComponent<HullTypeButton>().SetHullPieces(hullpieces);
			var hp = hullpieces;
			typeBtn.onClick.AddListener(() =>
			{
				_hb.Reset();
				_hb.CreateBase(hp);
			});
		}
	}
	
	void Update ()
	{
		
	}
}

public class HullTypeButton : MonoBehaviour
{
	HullPieces _pieces;

	public void SetHullPieces(HullPieces hp)
	{
		_pieces = hp;
	}
}
