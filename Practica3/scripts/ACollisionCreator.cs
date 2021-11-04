using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACollisionCreator : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.manager.ThrowACollision();
        }
    }
}
