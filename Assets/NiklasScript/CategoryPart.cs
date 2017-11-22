using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CategoryPart : MonoBehaviour
{
	public void OnPointerClick()
	{
		_customize.ActivateCollection(gameObject, Pieces);
    }

	public GameObject Item;
	public List<GameObject> Pieces;

	private Customize _customize;
	public void Start()
	{
    }

	public void SetPieces(List<GameObject> pieces)
	{
		Pieces = pieces;
    }

	public void SetAsset(GameObject go)
	{
		try
		{
			_customize = FindObjectOfType<Customize>();
			Item = go;
			var image = GetComponent<Image>();
			if (image != null)
			{
				image.sprite = null;
				var texture = AssetPreview.GetAssetPreview(go);
				Rect rec = new Rect(0, 0, texture.width, texture.height);
				var sprite = Sprite.Create(texture, rec, new Vector2(0, 0));
				image.sprite = sprite;
				
			}
		}
		catch(Exception e)
		{
			Debug.LogException(e);
		}
	}
}
