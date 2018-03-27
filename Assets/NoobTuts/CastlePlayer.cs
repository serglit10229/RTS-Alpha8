using UnityEngine;
using System.Collections;

public class CastlePlayer : MonoBehaviour {
    // Note: OnMouseDown only works if object has a collider
    public GameObject BuildGuide;


    public bool overlap = false;
    void OnMouseDown() {
        // use UnitSpawner
        Debug.Log("MouseDown");
        //GetComponent<UnitSpawner>().Spawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        overlap = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
        overlap = false;
    }

    private void OnTriggerStay(Collider other)
    {
        overlap = true;
    }
}