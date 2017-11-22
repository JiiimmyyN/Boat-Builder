using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Categorys : MonoBehaviour
{

	public GameObject CategoryTemplate;

	public List<HullPieces> hullPieces = new List<HullPieces>();
    void Start()
	{
		List<GameObject> objects = new List<GameObject>();
		foreach (HullPieces hullPiece in hullPieces)
		{
			objects.AddRange(hullPiece.Bows);
			objects.AddRange(hullPiece.Centers);
			objects.AddRange(hullPiece.Sterns);
			SetCategorys(objects);
			objects.Clear();
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
