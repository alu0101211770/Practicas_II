using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AProximityCreator : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 difference = player.transform.position - transform.position;
            GameManager.manager.ThrowAProximity();
        }
    }
}
