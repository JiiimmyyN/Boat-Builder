using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
	public GameObject Item;

	public void SetAsset(GameObject go)
	{
		Item = go;
		var image = GetComponent<Image>();
		if (image != null)
		{
			var texture = AssetPreview.GetAssetPreview(go);
			Rect rec = new Rect(0, 0, texture.width, texture.height);
			var sprite = Sprite.Create(texture, rec, new Vector2(0, 0));
			image.sprite = sprite;
		}
	}
}
