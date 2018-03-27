using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    Vector3 dir = new Vector3();
    public float speed = 5;
    public Transform target;

    public float delay = 2;
    public string enemyTag;
    public bool afterSpawn = false;

    void FixedUpdate() {
        if (target)
        {
            GetComponent<Rigidbody>().velocity = dir * speed;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void Fire(Transform dest)
    {
        dir = dest.position - transform.position;
    }
    
    void OnTriggerEnter(Collider co) {
        if (afterSpawn == true)
        {
            Destroy(gameObject);
            StopCoroutine("Delay");
        }
        if (co == target.gameObject) {
            --co.gameObject.GetComponent<Health>().current;
        }
    }


    private void Start()
    {
        StartCoroutine("Delay");
        StartCoroutine("AfterSpawn");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    IEnumerator AfterSpawn()
    {
        yield return new WaitForSeconds(delay);
        afterSpawn = true;
    }
}