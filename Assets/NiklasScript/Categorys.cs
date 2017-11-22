using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Categorys : MonoBehaviour
{

	public GameObject CategoryTemplate;

	public List<GameObject> categorys = new List<GameObject>();
    void Start()
	{
		SetCategorys(categorys);
    }

	public void SetCategorys(List<GameObject> categorys)
	{
		foreach (GameObject category in categorys)
		{
			var categoryObj = Instantiate(CategoryTemplate);
			categoryObj.SetActive(true);
            categoryObj.transform.parent = transform;
			var categoryPart = categoryObj.GetComponent<CategoryPart>();
			categoryPart.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(categoryPart.OnPointerClick);
			categoryPart.SetAsset(category);
			categoryPart.SetPieces(categorys);
        }
	}
}
