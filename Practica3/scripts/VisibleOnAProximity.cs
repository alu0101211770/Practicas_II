using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleOnAProximity : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Renderer>().enabled = false;
    }

    public Transform lookAtTransform;
    void OnEnable()
    {
        GameManager.OnAProximity += makeVisible;
    }


    void OnDisable()
    {
        GameManager.OnAProximity -= makeVisible;
    }


    void makeVisible()
    {
        GetComponent<Renderer>().enabled = true;
    }
}
