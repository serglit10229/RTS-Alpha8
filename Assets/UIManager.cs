using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {


	public GameObject Bot1UI;
	public GameObject Tank1UI;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void ShowUI (string factoryID, GameObject factory) {
		if (factoryID == "Bot1") 
		{
            List<GameObject> ls = new List<GameObject>();
            ls = Bot1UI.GetComponent<ButtonController>().Factory;
            Bot1UI.SetActive (true);
            if (!Bot1UI.GetComponent<ButtonController>().Factory.Contains(factory))
                Bot1UI.GetComponent<ButtonController>().addFactory(factory);
		}
		if (factoryID == "Tank1") 
		{
			List<GameObject> ls = new List<GameObject>();
			ls = Bot1UI.GetComponent<ButtonController>().Factory;
			Tank1UI.SetActive (true);
			if (!Tank1UI.GetComponent<ButtonController>().Factory.Contains(factory))
				Tank1UI.GetComponent<ButtonController>().addFactory(factory);
		}
	}

	public void HideUI(string factoryID)
	{
		if (factoryID == "Bot1") 
		{
			Bot1UI.GetComponent<ButtonController>().Factory.Clear();
            Bot1UI.SetActive (false);

		}
		if (factoryID == "Tank1") 
		{
			Tank1UI.GetComponent<ButtonController>().Factory.Clear();
			Tank1UI.SetActive (false);

		}
	}
}
