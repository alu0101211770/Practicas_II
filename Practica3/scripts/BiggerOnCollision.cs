using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            transform.localScale *= 1.2f;
        }
    }
}
