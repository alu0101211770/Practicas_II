using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerForceOnACollision : MonoBehaviour
{
    void OnEnable()
    {
        GameManager.OnACollision += AddForceToRepelledBySpace;
    }


    void OnDisable()
    {
        GameManager.OnACollision -= AddForceToRepelledBySpace;
    }


    void AddForceToRepelledBySpace()
    {
        RepelledBySpace repel = GetComponent<RepelledBySpace>();
        if (repel != null) 
        {
            repel.force *= 2;
        }

    }
}
