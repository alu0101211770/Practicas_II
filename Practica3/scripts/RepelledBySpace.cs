using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelledBySpace : MonoBehaviour
{
    public float force = 100;
    
    // Update is called once per frame
    void Update() 
    {
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            return;
        }
        if (Input.GetKeyDown("space"))
        {
            Rigidbody body = GetComponent<Rigidbody>();
            Vector3 direction = (transform.position - player.transform.position).normalized;
            body.AddForce(direction * force);
        }
    }

}
