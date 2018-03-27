using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    // attack range
    public float range = 5;

    // attack interval
    public float interval = 1.5f;
    
    // tag of the unit that should be attacked
    public string enemyTag = "";

    // arrow prefab (to shoot at enemies)
    public GameObject arrow;

    // check if player2(NPC)
    public bool Player2 = false;

    //True if enemy in sight
    public bool enemyDetected = false;

    public Vector3 scale = new Vector3(0.25f, 0.25f, 0.25f);


    public GameObject Bashnya;
    public Transform m_Target;
    public float m_Speed;
    // Use this for initialization
    void Start() {
        InvokeRepeating("Fire", interval, interval + 1);
    }

    void Update()
    {
        if (m_Target != null)
        {
            Vector3 lTargetDir = m_Target.position - Bashnya.transform.position;
            lTargetDir.y = 0.0f;
            Bashnya.transform.rotation = Quaternion.Lerp(Bashnya.transform.rotation, Quaternion.LookRotation(lTargetDir), Time.deltaTime * m_Speed);
        }
        if (m_Target == null)
        {
            Bashnya.transform.localRotation = Quaternion.Lerp(Bashnya.transform.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime);
        }
    }

    void Fire() {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag(enemyTag)) {
            // still alive?
            if (g != null) {
                // in attack range?	
                if (Vector3.Distance(g.transform.position, transform.position) >= range)
                {
                    m_Target = null;
                }
                if (Vector3.Distance(g.transform.position, transform.position) <= range) {
                    enemyDetected = true;
                    GameObject a = (GameObject)Instantiate(arrow, transform.position,Quaternion.identity);
                    a.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                    a.transform.LookAt(g.transform);

                    m_Target = g.transform;
                    // set its target
                    a.GetComponent<Arrow>().target = g.transform;
                    a.GetComponent<Arrow>().Fire(g.transform);

                    /*
                    if (Player2 == false)
                    {
                        a.GetComponent<Destroy>().enemyTag = "Enemy";
                    }
                    if (Player2 == true)
                    {
                        a.GetComponent<Destroy>().enemyTag = "Player";
                    }
                    */
                    break;
                }

            }
            if (g == null)
            {
                enemyDetected = false;
            }
        }
    }
}
