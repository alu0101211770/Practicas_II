using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtOnAProximity : MonoBehaviour
{
    public Transform lookAtTransform;
    void OnEnable()
    {
        GameManager.OnAProximity += LookAtTransform;
    }


    void OnDisable()
    {
        GameManager.OnAProximity -= LookAtTransform;
    }


    void LookAtTransform()
    {
        transform.LookAt(lookAtTransform);
        Debug.DrawRay(
            transform.position,
            lookAtTransform.position - transform.position,
            Color.white,
            100);
    }
}
