using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HullTypes : MonoBehaviour
{
	public Button HullTypePrototypeBtn;
	public Button PieceButtonPrototypeBtn;

	[Header("Parent")]
	public GridLayoutGroup PiecesParent;

	public List<HullPieces> Hulls;
	private HullBuilder _hb;

	void Start ()
	{
		//SceneManager.LoadSceneAsync("boat_testscene", LoadSceneMode.Additive);
		//Assert.IsFalse(Hulls == null, "No hulls!");

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

				RemoveChilds();
				CreateChilds(hp);
			});
		}
	}

	private void RemoveChilds()
	{
		int cc = PiecesParent.transform.childCount;
		for(int i = 0; i < cc; i++)
		{
			var c = PiecesParent.transform.GetChild(i);
			if(c.gameObject.activeInHierarchy)
			{
				Destroy(c.gameObject);
			}
		}
	}

	private void CreateChilds(HullPieces pieces)
	{
		foreach (var p in pieces.Centers)
		{
			try
			{
				var btn = Instantiate(PieceButtonPrototypeBtn, PiecesParent.transform);
				btn.gameObject.SetActive(true);
				var pp = p;
				btn.onClick.AddListener(() =>
				{
					_hb.AddCenterPiece(pp);
				});


				var img = btn.GetComponent<Image>();
				var tex = RuntimePreviewGenerator.GenerateModelPreview(pp.transform, 256, 256);
				img.sprite = Sprite.Create(tex, new Rect(0,0,tex.width,tex.height), Vector2.zero);
			}
			catch(Exception e)
			{
				Debug.LogException(e);
			}
		}
	}

	void OnDisable()
	{
		var objs = GameObject.FindObjectsOfType<MarkObject>();
		foreach (var obj in objs)
		{
			obj.enabled = false;
		}

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
