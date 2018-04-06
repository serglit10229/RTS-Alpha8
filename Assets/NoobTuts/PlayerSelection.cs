using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSelection : MonoBehaviour {    
    // Selection Circle
    public GameObject circle;
    //public GameObject tc;

	public UIManager UM;

	public UnitManager unitManager;

	public bool BotFactoryT1 = false;
	public bool TankFactoryT1 = false;

	public GameObject BotT1UI;
	public GameObject TankT1UI;
    public string unitType;

    public List<GameObject> dcObj;

    public int mouseClicks = 0;
    public float doubleClickTime = 1f;



    /////////////////////////////////////////////
    void OnMouseDown()
    {
        mouseClicks++;
        if (mouseClicks == 2 && (doubleClickTime - Time.deltaTime) >= 0)
        {
            OnDoubleClick();
            mouseClicks = 0;
            doubleClickTime = 1f;
        }
        if ((doubleClickTime - Time.deltaTime) <= 0 || mouseClicks >= 2)
        {
            mouseClicks = 0;
            doubleClickTime = 1f;
        }
    }


    /////////////////////////////////////////////

    void OnDoubleClick()
    {
        /*
        Debug.Log("OnDoubleClick");
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject g in FindObjectsOfType<GameObject>())
        {
            if (g != null && g != gameObject && !dcObj.Contains(g) && (gameObject.GetComponent("PlayerSelection") as PlayerSelection) != null && Vector3.Distance(transform.position, g.transform.position) <= 75f && g.GetComponent<PlayerSelection>().unitType == unitType)
            {
                dcObj.Add(g);
            }
        }
        */
    }
    void Update()
	{
		UM = GameObject.Find("UIManager").GetComponent<UIManager>();
		unitManager = GameObject.Find("UnitManager").GetComponent<UnitManager>();

        /*
        if (dcObj.Count > 0)
        {
            foreach (GameObject g in dcObj)
            {
                if (circle.activeSelf == true)
                {
                    Debug.Log("On Deselect");
                    OnDeselect();
                    g.GetComponent<PlayerSelection>().OnDeselect();
                }
                if (circle.activeSelf == false)
                {
                    Debug.Log("On Select");
                    OnSelect();
                    g.GetComponent<PlayerSelection>().OnSelect();
                }
            }
        }
        */
	}

    // OnSelect is called by the RTS Selection System
    void OnSelect() {
        Debug.Log("OnSelect");
        circle.SetActive(true);
        //tc.GetComponent<Count>().selectedUnits++;
        if(BotFactoryT1 != true && TankFactoryT1 != true)
            GetComponent<PlayerController>().selected = true;

		if (BotFactoryT1 == true) 
		{
            Debug.Log("ShowUI_SCRIPT");
            UM.ShowUI ("Bot1",gameObject);
		}
		if (TankFactoryT1 == true) 
		{
            UM.ShowUI("Tank1", gameObject);
        }
		if (TankFactoryT1 == false && BotFactoryT1 == false) 
		{
			if (!Camera.main.GetComponent<FormationController>().units.Contains (gameObject)) 
			{
                Camera.main.GetComponent<FormationController>().units.Add(gameObject);
			}
		}
    }
    
    // OnDeselect is called by the RTS Selection System
    void OnDeselect() {
        GetComponent<PlayerController>().army = false;
        Debug.Log("OnDeselect");
        circle.SetActive(false);
        //tc.GetComponent<Count>().selectedUnits--;
        if (BotFactoryT1 != true && TankFactoryT1 != true)
            GetComponent<PlayerController>().selected = false;

        if (BotFactoryT1 == true) 
		{
			UM.HideUI ("Bot1");
		}
		if (TankFactoryT1 == true) 
		{
            UM.HideUI("Tank1");
        }
        if (TankFactoryT1 == false && BotFactoryT1 == false)
        {
            if (Camera.main.GetComponent<FormationController>().units.Contains(gameObject))
            {
                GetComponent<PlayerController>().army = false;
                Camera.main.GetComponent<FormationController>().units.Remove(gameObject);
            }
        }
    }
}
