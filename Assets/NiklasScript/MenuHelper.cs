using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class MenuHelper
{

	//public static void FillGrid(List<GameObject> objects, GameObject template, Transform parent)
	//{
	//	foreach (GameObject obj in objects)
	//	{
	//		
	//		var categoryObj = GameObject.Instantiate(template);
	//		categoryObj.SetActive(true);
	//		categoryObj.transform.parent = parent;
	//		var categoryItem = categoryObj.GetComponent<Part>();
	//		categoryItem.SetAsset(obj);
	//	}
	//}
	//
	//public static void SetAsset(GameObject go, GameObject obj)
	//{
	//
	//	var image = obj.GetComponent<Image>();
	//	if (image != null)
	//	{
	//		Debug.Log("obj " + go.name);
	//		var texture = AssetPreview.GetAssetPreview(go);
	//		Rect rec = new Rect(0, 0, texture.width, texture.height);
	//		var sprite = Sprite.Create(texture, rec, new Vector2(0, 0));
	//		image.sprite = sprite;
	//	}
	//}
}
