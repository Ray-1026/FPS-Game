using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 2500);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
