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

}

