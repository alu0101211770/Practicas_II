using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public float destroyTime = 3f;
    private GameObject player;

    void Awake()
    {
        Destroy(gameObject, destroyTime);
        player = GameObject.Find("Player");
    }

    void Update() 
    {
        transform.LookAt(
            transform.position - (player.transform.position - transform.position)
        );
    }
}
