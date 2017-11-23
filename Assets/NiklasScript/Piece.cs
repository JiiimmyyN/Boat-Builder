using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour, IPointerClickHandler
{
	public GameObject Item;

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (Item != null)
		{
			var item = Instantiate(Item);
			item.AddComponent<PlaceAccessory>();
		}
	}
	public void SetAsset(GameObject go)
	{
		try
		{
			Item = go;
			var image = GetComponent<Image>();
			if (image != null)
			{

				var texture = AssetPreview.GetAssetPreview(go);
				if (texture != null)
				{
					Rect rec = new Rect(0, 0, texture.width, texture.height);
					var sprite = Sprite.Create(texture, rec, new Vector2(0, 0));
					image.sprite = sprite;
				}
				
			}
		}
		catch(Exception e)
		{
			Debug.LogException(e);
		}
	}
}
