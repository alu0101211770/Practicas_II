using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCollisionCreator : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.manager.ThrowBCollision();
        }
    }
}
