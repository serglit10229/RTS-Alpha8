using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public List<GameObject> units = new List<GameObject>();


    public bool BotFactoryT1 = false;
    public bool TankFactoryT1 = false;

    public List<GameObject> Factory = new List<GameObject>();

    // Use this for initialization
    void Update()
    {
        if (Factory != null)
        {
            /*
            if (Unit1.GetComponent<Button> ().onClick) {
             Factory.GetComponent<UnitSpawner> ().SpawnUnitBot1 ();
            }
            if (Unit2.GetComponent<Button> ().onClick) {
             Factory.GetComponent<UnitSpawner> ().SpawnUnitBot1 ();
            }
            if (Unit3.GetComponent<Button> ().onClick) {
             Factory.GetComponent<UnitSpawner> ().SpawnUnitBot1 ();
            }
            if (Unit4.GetComponent<Button> ().onClick) {
             Factory.GetComponent<UnitSpawner> ().SpawnUnitBot1 ();
            }
            */
        }
    }

    public void addFactory(GameObject factory)
    {
        Factory.Add(factory);
    }

    public void Unit1()
    {
        if (BotFactoryT1 == true)
        {

            foreach (GameObject go in Factory)
            {
                UnitSpawner us = go.GetComponent<UnitSpawner>();
                us.unit = units[0];
                us.prodTime = 5.0f;
                //Factory.GetComponent<UnitSpawner>().unitRequestAmount = 1;
                us.UnitRequest(1);
            }
        }
        if (TankFactoryT1 == true)
        {
            foreach (GameObject go in Factory)
            {
                UnitSpawner us = go.GetComponent<UnitSpawner>();
                us.unit = units[0];
                us.prodTime = 5.0f;
                //Factory.GetComponent<UnitSpawner>().unitRequestAmount = 1;
                us.UnitRequest(1);
            }
        }
    }
    void Unit2()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
    void Unit3()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
    void Unit4()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
    void Unit5()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
    void Unit6()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
    void Unit7()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
    void Unit8()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
    void Unit9()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
    void Unit10()
    {
        if (BotFactoryT1 == true)
        {

        }
        if (TankFactoryT1 == true)
        {

        }
    }
}