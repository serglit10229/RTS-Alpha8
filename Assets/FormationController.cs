using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour {
	public float unitsNumber;
	public List<GameObject> units;
	public List<Vector3> positions;

	Vector3 midPoint1;
	public Vector3 midPoint2;

	// Update is called once per frame
	void Update () {
		unitsNumber = GetComponent<RtsSelectionSystem>().unitsList.Count;
		units = GetComponent<RtsSelectionSystem>().unitsList;


		foreach(GameObject g in units)
		{
			if(!positions.Contains(g.transform.position))
				positions.Add(g.transform.position);
		}

		if(units.Count > 1)
		{
			Invoke("MidPoint", 0);
		}
	}

	void MidPoint()
	{
        Debug.Log("MidPoint");
		foreach(Vector3 pos in positions)
		{
			midPoint1 += pos;
		}
		midPoint2 = midPoint1 / units.Count;
	}
}
