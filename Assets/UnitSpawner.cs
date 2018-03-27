using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class UnitSpawner : MonoBehaviour
{
    // unit prefab
    //public GameObject unit;
    public float spawnRange = 1.5f;

    public float x = 0.075f;
    public float y = 0.5f;
    public float z = -0.1f;
    //public float angle = Random.Range(0.0f, 0.0f);
    public float speed1 = 0.2f;
    public float speed2 = 0.2f;

    public bool allowSpawn = false;
    public int unitAmount = 0;
    //public float prodTime = 0.0f;

    //PRODUCTION
    public GameObject unit;
    public float prodTime = 0.0f;
    //public int unitRequestAmount = 0;

    float prevTime = 0.0f;

    private void Update()
    {
        for (int i = 0; i < unitAmount; i++)
        {
            Debug.Log("Units To Make: " + unitAmount);
            prodTime -= Time.deltaTime;
            if (prodTime < 0)
            {
                Debug.Log("Unit Spawned");
                Vector3 pos = transform.position;
				//unit.GetComponent<NavMeshAgent>().enabled = false;
                Instantiate(unit, new Vector3(x + pos.x, y + pos.y, z + pos.z), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                //unit.GetComponent<NavMeshAgent>().enabled = true;
                unitAmount--;
                prodTime = prevTime;
            }
        }
    }
    public void UnitRequest(int unitRequestAmount)
    {
        prevTime = prodTime;
        unitAmount += unitRequestAmount;
    }
}