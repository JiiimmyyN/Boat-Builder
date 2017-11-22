using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Categorys : MonoBehaviour
{

	public GameObject CategoryTemplate;

	public Categories Categories;
    void Start()
	{
		
		foreach (RandomPieces pieces in Categories.Randoms)
		{
			//List<GameObject> objects = new List<GameObject>();
			//objects.AddRange(hullPiece.Bows);
			//objects.AddRange(hullPiece.Centers);
			//objects.AddRange(hullPiece.Sterns);
			SetCategorys(pieces.Objects);
			//objects.Clear();
        }
		
    }

	public void SetCategorys(List<GameObject> categorys)
	{

		var categoryObj = Instantiate(CategoryTemplate);
		categoryObj.SetActive(true);
        categoryObj.transform.parent = transform;
		var categoryPart = categoryObj.GetComponent<CategoryPart>();
		categoryPart.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(categoryPart.OnPointerClick);
		categoryPart.SetAsset(categorys[0]);
		List<GameObject> pieces = new List<GameObject>();
		pieces.AddRange(categorys);
        categoryPart.SetPieces(pieces);
        
	}
}
