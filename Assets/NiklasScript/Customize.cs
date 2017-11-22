using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize : MonoBehaviour
{

	public GameObject PieceCollection;
	public GameObject PieceCollectionTemplate;
	public GameObject PieceTemplate;

	public Dictionary<GameObject, GameObject> PieceCollections = new Dictionary<GameObject, GameObject>();

	private GameObject _current;
	public void ActivateCollection(GameObject go, List<GameObject> pieces)
	{
		if (!PieceCollections.ContainsKey(go))
		{
			var pieceCollectionTemplate = Instantiate(PieceCollectionTemplate, PieceCollection.transform);
			PieceCollections.Add(go, pieceCollectionTemplate);
			pieceCollectionTemplate.name = "PieceCollection";
            foreach (GameObject p in pieces)
			{
				var categoryObj = Instantiate(PieceTemplate);
				categoryObj.SetActive(true);
				categoryObj.transform.parent = pieceCollectionTemplate.transform;
				var piece = categoryObj.GetComponent<Piece>();
				piece.SetAsset(p);
			}
			if (_current == null)
			{
				_current = pieceCollectionTemplate;
			}
			else
			{
				_current.SetActive(false);
				pieceCollectionTemplate.SetActive(true);
				_current = pieceCollectionTemplate;
			}
		}
		else
		{
			_current.SetActive(false);
			PieceCollections[go].SetActive(true);
			_current = PieceCollections[go];
        }
	}
}
