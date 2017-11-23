using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "HullPieces", menuName = "Boat Builder/HullPieces", order = 0)]
public class HullPieces : ScriptableObject
{
	public List<GameObject> Bows;
	public List<GameObject> Centers;
	public List<GameObject> Sterns;

	void OnEnable()
	{
#if UNITY_EDITOR
		var tex = UnityEditor.AssetPreview.GetAssetPreview(Centers[0]);
		File.WriteAllBytes(string.Format("Assets/Resources/Generated/Hull/{0}.png", 0), tex.EncodeToPNG());
#else
		throw new NotImplementedException();
#endif
	}

}

